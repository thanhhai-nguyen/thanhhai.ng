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

public class Main {
    public static void main(String[] args) {
        String filename = "employees.txt";
        Scanner sc= new Scanner(System.in);
        Menu menu = new Menu();
        menu.add("1. Add employee ");
        menu.add("2. Remove employee by ID ");
        menu.add("3. Update information employee ");
        menu.add("4. Print list ");
        menu.add("5. Print in range ");
        menu.add("6. Save file ");
        menu.add("Other : Quit ");
        int choice;
        boolean change = false;
        EmpManager list = new EmpManager();
        list.addFile(filename);
        do{
            
            System.out.println("\n ");
            System.out.println("**********************************");
            System.out.println("*         EMPLOYEE MANAGER       *");
            System.out.println("**********************************");
            choice = menu.getChoice();
            switch(choice){
                case 1: list.addEmp(); change = true; break;
                case 2: list.remove(); change = true; break;
                case 3: list.update(); change = true; break;
                case 4: list.print(); break;
                case 5: list.printRange();break;
                case 6: list.saveFile(filename); change = false;
                    default: if(change){
                        System.out.print("Save ???? (Y/N) ");
                        String ans = sc.nextLine().toUpperCase();
                        if(ans.startsWith("Y"))
                            list.saveFile(filename);
                    }
            }
        } while (choice > 0 && choice < 7);
    }
}
