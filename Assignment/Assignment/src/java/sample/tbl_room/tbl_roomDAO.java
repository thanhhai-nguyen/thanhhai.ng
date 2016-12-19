/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_room;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import javax.naming.NamingException;
import sample.utils.DBUtils;

/**
 *
 * @author TTP
 */
public class tbl_roomDAO implements Serializable {

    public List<tbl_roomDTO> searchRoom(String roomID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        List<tbl_roomDTO> list = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String sql = "Select * From tbl_room Where roomID Like ?";
                stm = con.prepareStatement(sql);
                stm.setString(1, "%" + roomID + "%");
                rs = stm.executeQuery();
                while (rs.next()) {
                    if (list == null) {
                        list = new ArrayList<tbl_roomDTO>();
                    }
                    String id = rs.getString("roomID");
                    String description = rs.getString("description");
                    float hourPrice = rs.getFloat("hourPrice");
                    float dayPrice = rs.getFloat("dayPrice");
                    String cateID = rs.getString("categoryID");
                    tbl_roomDTO dto = new tbl_roomDTO(id, description, hourPrice, dayPrice, cateID);
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

    public List<tbl_roomDTO> showAll() throws NamingException, SQLException {
        Connection con = null;
        Statement stm = null;
        ResultSet rs = null;
        List<tbl_roomDTO> list = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String sql = "Select * From tbl_room";
                stm = con.createStatement();
                rs = stm.executeQuery(sql);
                while (rs.next()) {
                    if (list == null) {
                        list = new ArrayList<tbl_roomDTO>();
                    }
                    String id = rs.getString("roomID");
                    String description = rs.getString("description");
                    float hourPrice = rs.getFloat("hourPrice");
                    float dayPrice = rs.getFloat("dayPrice");
                    String category = rs.getString("categoryID");
                    tbl_roomDTO dto = new tbl_roomDTO(id, description, hourPrice, dayPrice, category);
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

    public boolean updateCate(String roomID, String cateID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String sql = "Update tbl_room Set categoryID=? Where roomID=?";
                stm = con.prepareStatement(sql);
                stm.setString(1, cateID);
                stm.setString(2, roomID);
                int r = stm.executeUpdate();
                if (r > 0) {
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
}
