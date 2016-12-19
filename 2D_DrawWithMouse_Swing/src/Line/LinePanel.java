/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Line;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.LinkedList;

/**
 *
 * @author Administrator
 */
public class LinePanel extends javax.swing.JPanel {

    LinkedList<Line> lineList = new LinkedList<>();
    Point startPnt = null, endPnt = null;
    Graphics g = null;
    Color color = Color.RED;

    public LinePanel() {
        initComponents();
    }

    public void addLine(Line line) {
        if (line != null) {
            lineList.add(line);
        }
    }

    public void setColor(Color color) {
        this.color = color;
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);             
        for (Line line : lineList) {
            Point p1 = line.startPoint;
            Point p2 = line.endPoint;
            g.setColor(line.color);
                g.drawLine(p1.x, p1.y, p2.x, p2.y);
        }
        g.setColor(color);
        if (startPnt != null && endPnt != null) {
                g.drawLine(startPnt.x, startPnt.y, endPnt.x, endPnt.y);
        }          
    }

    private void drawALine(Graphics g, Point star, Point end) {
        if (startPnt != null && endPnt != null) {
                g.drawLine(startPnt.x, startPnt.y, endPnt.x, endPnt.y);
        }
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        addMouseMotionListener(new java.awt.event.MouseMotionAdapter() {
            public void mouseDragged(java.awt.event.MouseEvent evt) {
                formMouseDragged(evt);
            }
        });
        addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                formMousePressed(evt);
            }
            public void mouseReleased(java.awt.event.MouseEvent evt) {
                formMouseReleased(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents

    private void formMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMousePressed
        startPnt = evt.getPoint();
        g = this.getGraphics();
        g.setColor(color);
    }//GEN-LAST:event_formMousePressed

    private void formMouseReleased(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseReleased
        endPnt = evt.getPoint();
        if (startPnt == null || endPnt == null) {
            return;
        }
        addLine(new Line(startPnt, endPnt, color));
        drawALine(g, startPnt, endPnt);
        startPnt = endPnt = null;
    }//GEN-LAST:event_formMouseReleased

    private void formMouseDragged(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseDragged
        endPnt = evt.getPoint();
        repaint();       
    }//GEN-LAST:event_formMouseDragged


    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
