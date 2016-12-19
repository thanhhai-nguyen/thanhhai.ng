/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.tbl_orderDetail;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_orderDetailDTO implements Serializable {

    private int ID;
    private String productname;
    private String unititem;
    private int quantity;
    private float price;
    private float total;

    public tbl_orderDetailDTO() {
    }

    public tbl_orderDetailDTO(int ID, String productname, String unititem, int quantity, float price, float total) {
        this.ID = ID;
        this.productname = productname;
        this.unititem = unititem;
        this.quantity = quantity;
        this.price = price;
        this.total = total;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getProductname() {
        return productname;
    }

    public void setProductname(String productname) {
        this.productname = productname;
    }

    public String getUnititem() {
        return unititem;
    }

    public void setUnititem(String unititem) {
        this.unititem = unititem;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        this.price = price;
    }

    public float getTotal() {
        return total;
    }

    public void setTotal(float total) {
        this.total = total;
    }
    
    
}