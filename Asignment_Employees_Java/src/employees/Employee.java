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
import java.util.Comparator;

public class Employee implements Comparable<Employee>{
   
    @Override
    public int compareTo(Employee e){
        return Comparators.EMP.compare(this, e);
    }
    
    public static class Comparators{
        public static Comparator<Employee> EMP = (Employee  e1, Employee e2) ->
        {
            int i = e1.ID.compareTo(e2.ID);
            return i;
        };
    }
    
    private String ID, name, address;
    private Double salary,allowance;
    
    public Employee( String ID, String name, String address, Double salary, Double allow){
        this.ID = ID;
        this.name= name;
        this.address = address;
        this.salary= salary;
        this.allowance = allow;
    }

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Double getSalary() {
        return salary;
    }

    public void setSalary(Double salary) {
        this.salary = salary;
    }

    public Double getAllowance() {
        return allowance;
    }

    public void setAllowance(Double allowance) {
        this.allowance = allowance;
    }
    
    public void output(){
        System.out.printf(" %-10s | %-20s | %-20s | %-10.2f | %-10.2f ",this.ID,name,address,salary,allowance);
    }
    
}
