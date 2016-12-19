/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_orderDetail;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import javax.naming.NamingException;
import sample.DBUtils.DBUtils;

/**
 *
 * @author TTP
 */
public class tbl_orderDetailDAO implements Serializable {

    public List<tbl_orderDetailDTO> items = null;

    public List<tbl_orderDetailDTO> getItems() {
        return items;
    }

    public void searchByOrderID(String orderID) throws SQLException, NamingException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select* from tbl_orderDetail where orderID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, orderID);
            rs = stm.executeQuery();
            while (rs.next()) {
                String productID = rs.getString("productID");
                //String productName = dao.searchname(productID);              
                String unit = rs.getString("unitItem");
                int quatity = rs.getInt("quantity");
                float price = rs.getFloat("unitPrice");
                float total = rs.getFloat("total");
                int id = rs.getInt("id");
                tbl_orderDetailDTO dto = new tbl_orderDetailDTO(id, productID, unit, quatity, price, total);
                if (items == null) {
                    items = new ArrayList<tbl_orderDetailDTO>();
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

    public float searchForTotal(String orderID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select * from tbl_orderDetail where orderID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, orderID);
            rs = stm.executeQuery();
            float sum = 0;
            while (rs.next()) {
                float total = rs.getFloat("total");
                sum = sum + total;
            }
            return sum;
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

    public int searchQuantity(String productID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select * from tbl_orderDetail where productID = ? ";
            stm = con.prepareStatement(sql);
            stm.setString(1, productID);
            rs = stm.executeQuery();
            int quantity = 0;
            while (rs.next()) {
                quantity = rs.getInt("quantity");
            }

            return quantity;
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

    public void updateQuantity(int id, int quantity, float price) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Update tbl_orderDetail Set quantity = ?, total = ? where id = ? ";
            stm = con.prepareStatement(sql);
            stm.setInt(1, quantity);
            stm.setFloat(2, price * quantity);
            stm.setInt(3, id);
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

    public void deleteItem(int ID) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Delete From tbl_orderDetail where id =? ";
            stm = con.prepareStatement(sql);
            stm.setInt(1, ID);
            int result = stm.executeUpdate();

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
}
