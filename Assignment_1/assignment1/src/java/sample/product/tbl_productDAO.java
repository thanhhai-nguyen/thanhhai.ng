/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.product;

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
public class tbl_productDAO implements Serializable{
    public int searchQuantity(String productID) throws NamingException, SQLException{
        Connection con = null;
        PreparedStatement stm= null;
        ResultSet rs = null;
        try{
            con= DBUtils.makeConnection();
            String sql = "Select * From tbl_product where productID = ?";
            stm = con.prepareStatement(sql);
            stm.setString(1, productID);
            rs= stm.executeQuery();
            int quantity = 0;
            while(rs.next()){
                quantity = rs.getInt("quantity");
            }
            return quantity;
        }finally{
            if(con != null){
                con.close();
            }if(stm != null){
                stm.close();
            }if(rs != null){
                rs.close();
            }
        }
    }
    
    public void updateQuantity(String productID, int quantity) throws SQLException, NamingException{
        Connection con = null;
        PreparedStatement stm= null;
        try{
            con= DBUtils.makeConnection();
            String sql = "Update tbl_product Set quantity = ? where productID =?";
            stm = con.prepareStatement(sql);
            stm.setInt(1, quantity);
            stm.setString(2, productID);
            stm.executeUpdate();
        }finally{
            if(con != null){
                con.close();
            }if(stm != null){
                stm.close();
            }
        }
    }
}
