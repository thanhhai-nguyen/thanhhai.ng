/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_maintenance;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import javax.naming.NamingException;
import sample.tbl_room.tbl_roomDTO;
import sample.utils.DBUtils;

/**
 *
 * @author TTP
 */
public class tbl_maintenanceDAO implements Serializable {

    public List<tbl_maintenanceDTO> searchDate(String date) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        List<tbl_maintenanceDTO> list = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String sql = "Select * from tbl_maintenance where requestDate = ? ";
                stm = con.prepareStatement(sql);
                stm.setString(1, date);
                rs = stm.executeQuery();
                while (rs.next()) {
                    if (list == null) {
                        list = new ArrayList<tbl_maintenanceDTO>();
                    }
                    String roomId = rs.getString("roomId");
                    String reason = rs.getString("reason");
                    String mend = rs.getString("mend");
                    float cost = rs.getFloat("cost");
                    int id = rs.getInt("id");
                    tbl_maintenanceDTO dto = new tbl_maintenanceDTO(id, roomId, reason, mend, cost);
                    list.add(dto);
                }
            }
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (con != null) {
                con.close();
            }
        }
        return list;
    }

    public boolean createReport(String requestUser, String roomID, String reason, Date requestDate) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                con = DBUtils.makeConnection();
                if (con != null) {
                    String sql = "Insert Into tbl_maintenance(requestDate, reason, roomID, RequestUser)"
                            + " Values(?,?,?,?)";
                    stm = con.prepareStatement(sql);
//                    int id = getNewID();
//                    stm.setInt(1, id);
                    stm.setDate(1, requestDate);
                    stm.setString(2, reason);
                    stm.setString(3, roomID);
                    stm.setString(4, requestUser);
                    int r = stm.executeUpdate();
                    if (r > 0) {
                        return true;
                    }
                }
            }
        } finally {
            if (stm != null) {
                stm.close();
            }
            if (con != null) {
                con.close();
            }
        }
        return false;
    }

    public boolean updateReport(String repairUser, int Id, String mend, float cost) throws SQLException, NamingException {
        Connection con = null;
        PreparedStatement stm = null;//làm 1 cái thôi
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                //for(int i =0; i < Id.len; i++){
                String sql = "Update tbl_maintenance set mend = ?, cost = ? , repairedUser = ?, repairedDate = GETDATE() where id =? ";
                // update reparedUser
                stm = con.prepareStatement(sql);
                stm.setString(1, mend);
                stm.setFloat(2, cost);
                stm.setString(3, repairUser);
                stm.setInt(4, Id);
                int result = stm.executeUpdate();
                if (result > 0) {
                    return true;
                }

            }
        } finally {
            if (stm != null) {
                stm.close();
            }
            if (con != null) {
                con.close();
            }

        }
        return false;
    }

    private int getNewID() throws NamingException, SQLException {
        Connection con = null;
        Statement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                con = DBUtils.makeConnection();
                if (con != null) {
                    String sql = "Select MAX(id) As MaxId From tbl_maintenance";
                    stm = con.createStatement();
                    rs = stm.executeQuery(sql);
                    if (rs.next()) {
                        int max = rs.getInt("MaxId");
                        return max + 1;
                    }
                }
            }
        } finally {
            if (rs != null) {
                rs.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (con != null) {
                con.close();
            }
        }
        return 1;
    }
}
