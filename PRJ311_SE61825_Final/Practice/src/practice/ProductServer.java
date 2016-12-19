/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package practice;

import java.rmi.server.UnicastRemoteObject;
import java.util.*;
import java.io.*;
import java.rmi.RemoteException;

/**
 *
 * @author Administrator
 */
public class ProductServer extends UnicastRemoteObject implements ProductMngInterface {

    String fileName = "product.txt";

    public ProductServer(String fileName) throws RemoteException{
        super();
        this.fileName  = fileName;
    }

    @Override
    public Vector getInitinalData() throws RemoteException {
        Vector data = new Vector(0);
        try {
            FileReader r = new FileReader(fileName);
            BufferedReader br = new BufferedReader(r);
            String line;
            StringTokenizer stk;
            String code, name;
            String date;
            int year;
            int salary;
            while ((line = br.readLine()) != null) {
                stk = new StringTokenizer(line, ",");
                Vector v = new Vector();
                v.add(stk.nextToken());// code
                v.add(stk.nextToken());// name 
                v.add(Integer.parseInt(stk.nextToken()));//salary
                v.add(stk.nextToken());//date
                v.add(Integer.parseInt(stk.nextToken()));// year
                data.add(v);
            }
            br.close();
            r.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return data;
    }

    @Override
    public boolean saveList(Vector data) throws RemoteException {
        try {
            FileWriter f = new FileWriter(fileName);
            PrintWriter pw = new PrintWriter(f);
            for (int i = 0; i < data.size(); i++) {
                Vector v = ((Vector) (data.get(i)));
                String S = "";
                S += v.get(0) + "," + v.get(1) + "," + v.get(2) + "," + v.get(3) + "," + v.get(4);
                pw.println(S);
            }
            pw.close();
            f.close();
            return true;
        } catch (Exception e) {
            return false;
        }
    }

}
