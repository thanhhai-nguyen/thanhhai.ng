/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package sample.tbl_maintenance;

import java.io.Serializable;

/**
 *
 * @author TTP
 */
public class tbl_maintenanceDTO implements Serializable{
    private int id;
    private String roomID;
    private String reason;
    private String mend;
    private float cost;

    public tbl_maintenanceDTO() {
    }
    

    public tbl_maintenanceDTO(int id, String roomID, String reason, String mend, float cost) {
        this.id = id;
        this.roomID = roomID;
        this.reason = reason;
        this.mend = mend;
        this.cost = cost;
    }

    /**
     * @return the id
     */
    public int getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return the roomID
     */
    public String getRoomID() {
        return roomID;
    }

    /**
     * @param roomID the roomID to set
     */
    public void setRoomID(String roomID) {
        this.roomID = roomID;
    }

    /**
     * @return the reason
     */
    public String getReason() {
        return reason;
    }

    /**
     * @param reason the reason to set
     */
    public void setReason(String reason) {
        this.reason = reason;
    }

    /**
     * @return the mend
     */
    public String getMend() {
        return mend;
    }

    /**
     * @param mend the mend to set
     */
    public void setMend(String mend) {
        this.mend = mend;
    }

    /**
     * @return the cost
     */
    public float getCost() {
        return cost;
    }

    /**
     * @param cost the cost to set
     */
    public void setCost(float cost) {
        this.cost = cost;
    }
    
    
}
