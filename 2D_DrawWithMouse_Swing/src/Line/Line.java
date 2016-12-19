/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Line;

import java.awt.Color;
import java.awt.Point;
/**
 *
 * @author Administrator
 */
public class Line{
    Point startPoint = null, endPoint = null;
    Color color = null;
    public Line(Point start, Point end, Color color) {
        startPoint = start;
        endPoint = end;
        this.color = color;
    }
}
