/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.tbl_room;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_roomReportError implements Serializable{
    private String emptyField;
    private String tooLongField;

    public String getEmptyField() {
        return emptyField;
    }

    public void setEmptyField(String emptyField) {
        this.emptyField = emptyField;
    }

    public String getTooLongField() {
        return tooLongField;
    }

    public void setTooLongField(String tooLongField) {
        this.tooLongField = tooLongField;
    }
    
    
}
