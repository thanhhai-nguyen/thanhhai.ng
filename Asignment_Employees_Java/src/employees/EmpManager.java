/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package employees;

/**
 *
 * @author Administrator
 */
import java.util.Scanner;
import java.util.Vector;
import java.io.*;
import java.util.*;
import java.util.StringTokenizer;
import java.util.Collections;

public class EmpManager extends Vector<Employee> {

    Scanner sc = new Scanner(System.in);

    public EmpManager() {
        super();
    }

    public void addFile(String fName) {
        try {
            File f = new File(fName);
            if (!f.exists()) {
                return;
            }
            FileReader fr = new FileReader(f);
            BufferedReader bf = new BufferedReader(fr);
            String details;
            while ((details = bf.readLine()) != null) {
                StringTokenizer stk = new StringTokenizer(details, ",");
                String ID = stk.nextToken().toUpperCase();
                String name = stk.nextToken().toUpperCase();
                String address = stk.nextToken().toUpperCase();
                double salary = Double.parseDouble(stk.nextToken());
                double allow = Double.parseDouble(stk.nextToken());

                Employee emp = new Employee(ID, name, address, salary, allow);
                this.add(emp);
            }
            bf.close();
            fr.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public void saveFile(String fName) {
        if (this.size() == 0) {
            System.out.println("List empty.");
            return;
        }
        try {
            File f = new File(fName);
            FileWriter fw = new FileWriter(f);
            PrintWriter pw = new PrintWriter(fw);
            for (Employee x : this) {
                pw.println(x.getID() + "," + x.getName() + "," + x.getAddress() + "," + x.getSalary() + "," + x.getAllowance());
            }
            pw.close();
            fw.close();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public int find(String fID) {
        for (int i = 0; i < this.size(); i++) {
            if (this.get(i).getID().equals(fID)) {
                return i;
            }
        }
        return -1;
    }

    public void addEmp() {
        String newID, newName, newAddress;
        Double newSalary, newAllow;
        Scanner sc = new Scanner(System.in);
        int pos;
        boolean valid = true;
        do {
            System.out.print("Enter ID ( E000 ): ");
            newID = sc.nextLine().toUpperCase();
            pos = find(newID);
            if (pos >= 0) {
                System.out.println("Code exist .");
            }
            valid = newID.matches("^E\\d{3}$");
            if (!valid) {
                System.out.println("Valid ID.");
            }
        } while ((!valid) || (pos >= 0));
        System.out.print("Enter name employee: ");
        newName = sc.nextLine().toUpperCase();
        System.out.print("Enter address employee: ");
        newAddress = sc.nextLine().toUpperCase();
        System.out.print("Enter salary: ");
        newSalary = Double.parseDouble(sc.nextLine());
        System.out.print("Enter Allowance: ");
        newAllow = Double.parseDouble(sc.nextLine());

        Employee c = new Employee(newID, newName, newAddress, newSalary, newAllow);
        this.add(c);
        System.out.println("New employee have been add success.");
    }

    public void remove() {
        int pos;
        if (this.isEmpty()) {
            System.out.println("List is Empty.");
            return;
        }
        String reID;
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter ID of motor want to delete: ");
        reID = sc.nextLine().toUpperCase();
        pos = find(reID);
        if (pos < 0) {
            System.out.println("Input motor is not on the list .");
        } else {
            this.remove(pos);
            System.out.println("Motor " + reID + " has been removed.");
        }
    }

    public void sort() {
        if (this.size() == 0) {
            System.out.println("List is empty.");
        }
        Collections.sort(this, Employee.Comparators.EMP);
    }

    public void update() {
        String upID;
        System.out.print("Enter ID of employee want to update: ");
        upID = sc.nextLine().toUpperCase();
        int pos = find(upID);
        if (pos < 0) {
            System.out.println("The ID is not correct.");
        } else {
            String oldName = this.get(pos).getName();
            String oldAddress = this.get(pos).getAddress();
            double oldSalary = this.get(pos).getSalary();
            double oldAllow = this.get(pos).getAllowance();
            String newName, newAddress;
            double newSalary, newAllow;
            System.out.print("Input new name: ");
            newName = sc.nextLine().toUpperCase();
            System.out.print("Input new address: ");
            newAddress = sc.nextLine().toUpperCase();
            System.out.print("Input new salary: ");
            newSalary = Double.parseDouble(sc.nextLine());
            System.out.print("Input new allowance: ");
            newAllow = Double.parseDouble(sc.nextLine());
            this.get(pos).setName(newName);
            this.get(pos).setAddress(newAddress);
            this.get(pos).setSalary(newSalary);
            this.get(pos).setAllowance(newAllow);
            System.out.println("Update complete.");
        }
    }

    public void print() {
        if (this.size() == 0) {
            System.out.println(sc);
            return;
        }
        Collections.sort(this);
        System.out.println("***********************");
        System.out.println("EMPLOYEES LIST");
        System.out.println("***********************");
        for (int i = 0; i < this.size(); i++) {
            this.get(i).output();
        }
        System.out.println("\n");
    }

    public void printRange() {
        Double start, end, tmp;
        Scanner sc = new Scanner(System.in);
        System.out.print("Input start income: ");
        start = Double.parseDouble(sc.nextLine());
        System.out.print("Input end income: ");
        end = Double.parseDouble(sc.nextLine());
        Collections.sort(this);
        System.out.println("***********************");
        System.out.println("EMPLOYEES LIST");
        System.out.println("***********************");
        for (int i = 0; i < this.size(); i++) {
            Double income = this.get(i).getSalary() + this.get(i).getAllowance();
            if (income <= end && income >= start) {
                this.get(i).output();
                System.out.printf("| %-10f", income);
            }
        }
        System.out.println("\n");
    }
}
