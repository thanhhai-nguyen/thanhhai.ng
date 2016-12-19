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

public class Menu extends Vector<String>{
    public Menu() {
        super();
    }

    void addMenu(String S) {
        this.add(S);
    }

    public int getChoice() {
        for (int i = 0; i < this.size(); i++) //**************** this.size let we know the size of an array *********
        {
            System.out.println(this.get(i));
        }
        int c;
        Scanner sc = new Scanner(System.in);
        System.out.print("Choose: ");
        while (!sc.hasNextInt()) {
            System.out.print("Choose:");
            sc.next();
        }
        c = sc.nextInt();
        return c;
    }
    
}
