/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FillShape;

import java.awt.Color;
import java.awt.Point;

/**
 *
 * @author Administrator
 */
public class Component {
    Point startPoint = null, endPoint = null;
    int left, top, width, height;
    boolean fill;
    Color color = null;
    
    public Component(Point start, Point end) {
        startPoint = start;
        endPoint = end;
        this.left = start.x < end.x ? start.x : end.x;;
        this.top = start.y < end.y ? start.y : end.y;
        this.width = Math.abs(start.x - end.x);
        this.height = Math.abs(start.y - end.y);
    } 

    public Component(Point start, Point end, boolean fill, Color c) {
        startPoint = start;
        endPoint = end;
        this.left = start.x < end.x ? start.x : end.x;;
        this.top = start.y < end.y ? start.y : end.y;
        this.width = Math.abs(start.x - end.x);
        this.height = Math.abs(start.y - end.y);
        this.fill = fill;
        color = c;
    }        
}
