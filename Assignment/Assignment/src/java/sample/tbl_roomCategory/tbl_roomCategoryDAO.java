/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_roomCategory;

import java.io.Serializable;
import java.sql.Connection;
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
public class tbl_roomCategoryDAO implements Serializable {

    public List<tbl_roomCategoryDTO> loadAllCate() throws SQLException, NamingException {
        Connection con = null;
        Statement stm = null;
        ResultSet rs = null;
        List<tbl_roomCategoryDTO> list = null;
        try {
            con = DBUtils.makeConnection();
            if(con != null){
               String sql = "Select * From tbl_roomCategory"; 
               stm = con.createStatement();
               rs = stm.executeQuery(sql);
               while(rs.next()){
                   if(list == null){
                       list = new ArrayList<tbl_roomCategoryDTO>();
                   }
                   String id = rs.getString("categoryID");
                   String name = rs.getString("categoryName");
                   tbl_roomCategoryDTO dto = new tbl_roomCategoryDTO(id, name);
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
}