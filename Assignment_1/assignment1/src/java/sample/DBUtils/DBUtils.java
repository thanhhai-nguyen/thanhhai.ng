/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.DBUtils;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.SQLException;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;

/**
 *
 * @author TTP
 */
public class DBUtils implements Serializable {

    public static Connection makeConnection() throws NamingException, SQLException {
        Context context = new InitialContext();
        Context severContext = (Context) context.lookup("java:comp/env");
        DataSource ds = (DataSource) severContext.lookup("assignment1");
        Connection con = ds.getConnection();
        return con;
    }
}
