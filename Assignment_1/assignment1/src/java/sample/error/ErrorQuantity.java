/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.error;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class ErrorQuantity implements Serializable{
    private String quantity;

    public ErrorQuantity() {
    }

    public ErrorQuantity(String quantity) {
        this.quantity = quantity;
    }

    public String getQuantity() {
        return quantity;
    }

    public void setQuantity(String quantity) {
        this.quantity = quantity;
    }
    
}
