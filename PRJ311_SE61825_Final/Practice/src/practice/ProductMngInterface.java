/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package practice;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.Vector;

/**
 *
 * @author Administrator
 */
public interface ProductMngInterface extends Remote{
    
    Vector getInitinalData() throws RemoteException;
    boolean saveList(Vector data) throws RemoteException;
    
}
