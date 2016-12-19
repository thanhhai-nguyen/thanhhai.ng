/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_account;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_accountDTO implements Serializable {

    private String username;
    private int role;

    public tbl_accountDTO() {
    }

    public tbl_accountDTO(String username, int role) {
        this.username = username;
        this.role = role;
    }

    /**
     * @return the username
     */
    public String getUsername() {
        return username;
    }

    /**
     * @param username the username to set
     */
    public void setUsername(String username) {
        this.username = username;
    }

    /**
     * @return the role
     */
    public int getRole() {
        return role;
    }

    /**
     * @param role the role to set
     */
    public void setRole(int role) {
        this.role = role;
    }

    public String getRoleName() {
        switch (this.role) {
            case 0:
                return "admin";
            case 1:
                return "staff";
            case 2:
                return "user";
            case 3:
                return "manager";
            default:
                return "";
        }
    }
}
