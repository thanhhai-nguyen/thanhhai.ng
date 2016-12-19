/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_order;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import javax.naming.NamingException;
import javax.swing.JOptionPane;
import sample.DBUtils.DBUtils;
import sample.tbl_orderDetail.tbl_orderDetailDAO;

/**
 *
 * @author TTP
 */
public class tbl_orderDAO implements Serializable {

    public List<tbl_orderDTO> items = null;

    public List<tbl_orderDTO> getItems() {
        return items;
    }

    public void searchByDate(String dateFrom, String dateTo, String customerid) throws SQLException, NamingException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select * from tbl_order where orderDate between'"
                    + dateFrom + " 00:00:00' and '" + dateTo + " 23:59:00' and customerID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, customerid);
            rs = stm.executeQuery();
            while (rs.next()) {
                String orderID = rs.getString("orderID");
                Date date = rs.getDate("orderDate");
                String customerID = rs.getString("customerID");
                tbl_orderDetailDAO dao = new tbl_orderDetailDAO();
                float total = dao.searchForTotal(orderID);
                String phone = rs.getString("phone");
                String address = rs.getString("address");
                tbl_orderDTO dto = new tbl_orderDTO(orderID, date.toString(), customerID, total, phone, address);
                if (items == null) {
                    items = new ArrayList<tbl_orderDTO>();
                }
                items.add(dto);
            }
        } finally {
            if (con != null) {
                con.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (rs != null) {
                rs.close();
            }
        }
    }

    public float checkQuantity(String orderID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select * from tbl_order where orderID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, orderID);
            rs = stm.executeQuery();
            float total=0;
            while (rs.next()) {
                total = rs.getFloat("total");
                System.out.println("total " + total);
            }

            return total;
        } finally {
            if (con != null) {
                con.close();
            }
            if (stm != null) {
                stm.close();
            }
            if (rs != null) {
                rs.close();
            }
        }
    }

    public void deleteRecord(String orderID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Delete From tbl_order where orderID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, orderID);
            stm.executeUpdate();
        } finally {
            if (con != null) {
                con.close();
            }
            if (stm != null) {
                stm.close();
            }
        }
    }
    
    public void updateRecord(String orderID, float total) throws NamingException, SQLException{
        Connection con = null;
        PreparedStatement stm = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Update tbl_order Set total = ? where orderID = ?";
            stm = con.prepareStatement(sql);
            stm.setFloat(1, total);
            stm.setString(2, orderID);
            stm.executeUpdate();
        } finally {
            if (con != null) {
                con.close();
            }
            if (stm != null) {
                stm.close();
            }
        }
    }
    
}
