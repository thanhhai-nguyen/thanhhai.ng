/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.account;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.naming.NamingException;
import sample.DBUtils.DBUtils;

/**
 *
 * @author TTP
 */
public class tbl_accountDAO implements Serializable {

    private String customername;
    private String customerID;

    public tbl_accountDAO() {
    }

    public tbl_accountDAO(String customername, String customerID) {
        this.customername = customername;
        this.customerID = customerID;
    }

    public String getCustomerID() {
        return customerID;
    }

    public void setCustomerID(String customerID) {
        this.customerID = customerID;
    }

    

    public String getCustomername() {
        return customername;
    }

    public void setCustomername(String customername) {
        this.customername = customername;
    }

    public boolean checkLogin(String username, String password) throws NamingException, SQLException {
        Connection con = null;
        PreparedStatement stm = null;
        ResultSet rs = null;
        try {
            con = DBUtils.makeConnection();
            String sql = "Select * from tbl_account where accountID = ? and password = ? ";
            stm = con.prepareStatement(sql);
            stm.setString(1, username);
            stm.setString(2, password);
            rs = stm.executeQuery();
            if (rs.next()) {
                String customerID= rs.getString("accountID");
                String name = rs.getString("customerName");
                this.setCustomername(name);
                this.setCustomerID(customerID);
                return true;
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
        return false;
    }

    public boolean insertRecord(String username, String password, String fullname, String email) throws ClassNotFoundException, SQLException, NamingException {
        Connection con = null;
        PreparedStatement stm = null;

        try {
            con = DBUtils.makeConnection();
            String sql = "Insert into tbl_account(accountID, customerName, password, email) Values (?,?,?,?) ";
            stm = con.prepareStatement(sql);
            stm.setString(1, username);
            stm.setString(2, fullname);
            stm.setString(3, password);
            stm.setString(4, email);
            int row = stm.executeUpdate();
            if (row > 0) {
                return true;
            }
        } finally {
            if (con != null) {
                con.close();
            }
            if (stm != null) {
                stm.close();
            }
        }

        return false;
    }

}
