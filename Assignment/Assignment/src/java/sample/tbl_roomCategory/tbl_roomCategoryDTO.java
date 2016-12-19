/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.tbl_roomCategory;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_roomCategoryDTO implements Serializable{
    private String categoryID;
    private String name;

    public tbl_roomCategoryDTO() {
    }

    public tbl_roomCategoryDTO(String categoryID, String name) {
        this.categoryID = categoryID;
        this.name = name;
    }

    public String getCateID() {
        return categoryID;
    }

    public void setCategID(String categoryID) {
        this.categoryID = categoryID;
    }

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }
    
    
}
