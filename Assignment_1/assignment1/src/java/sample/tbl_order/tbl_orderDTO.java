/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.tbl_order;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_orderDTO implements Serializable{
    private String orderID ;
    private String date ;
    private String customerID ;
    private float total;
    private String phone;
    private String address;

    public tbl_orderDTO() {
    }

    public tbl_orderDTO(String orderID, String date, String customerID, float total, String phone, String address) {
        this.orderID = orderID;
        this.date = date;
        this.customerID = customerID;
        this.total = total;
        this.phone = phone;
        this.address = address;
    }

    public String getOrderID() {
        return orderID;
    }

    public void setOrderID(String orderID) {
        this.orderID = orderID;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getCustomerID() {
        return customerID;
    }

    public void setCustomerID(String customerID) {
        this.customerID = customerID;
    }

    public float getTotal() {
        return total;
    }

    public void setTotal(float total) {
        this.total = total;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }
     
}
