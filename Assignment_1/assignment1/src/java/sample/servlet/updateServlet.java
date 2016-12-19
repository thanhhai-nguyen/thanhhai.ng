/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.NamingException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import sample.error.ErrorQuantity;
import sample.product.tbl_productDAO;
import sample.tbl_order.tbl_orderDAO;
import sample.tbl_orderDetail.tbl_orderDetailDAO;

/**
 *
 * @author TTP
 */
public class updateServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException, NamingException, SQLException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        try {
            HttpSession session = request.getSession(false);
            ErrorQuantity err = new ErrorQuantity();
            if (session != null) {
                String quantity = request.getParameter("txtquatity");
                String ID = request.getParameter("ID");
                String txtoldQuantity = request.getParameter("txtoldquatity");
                String productID = request.getParameter("txtproductID");
                String txtPrice = request.getParameter("price");
                String orderID = request.getParameter("orderID");
                float price = Float.parseFloat(txtPrice);
                int newQuan = Integer.parseInt(quantity);
                int oldQuan = Integer.parseInt(txtoldQuantity);
                // check done quantity 
                tbl_orderDetailDAO detailDAO = new tbl_orderDetailDAO();
                int useQuantity = detailDAO.searchQuantity(productID);
                // check stock quantity
                tbl_productDAO productDAO = new tbl_productDAO();
                int realQuantity = productDAO.searchQuantity(productID);
                ////
                float total =0;
                ///
                // enough quantity 
                if (((newQuan + useQuantity) - oldQuan) < realQuantity) {
                    int productQuantity = (realQuantity + oldQuan) - newQuan;
                    
                    // update tbl_detail
                    detailDAO.updateQuantity(Integer.parseInt(ID), newQuan, price);
                    // update tbl_product
                    productDAO.updateQuantity(productID, productQuantity);
                    // update tbl_order
                    tbl_orderDAO orderDAO = new tbl_orderDAO();
                    total = detailDAO.searchForTotal(orderID);
                    orderDAO.updateRecord(productID, total);
                } else {
                    err.setQuantity("New quantity must be < " + (realQuantity - useQuantity));
                    request.setAttribute("ERR", err);
                }
               
                 String urlRewriting = "ProcessServlet?btAction=detail" 
                          + "&total=" + total;
                
                RequestDispatcher rd = request.getRequestDispatcher(urlRewriting);
                rd.forward(request, response);

            } else {
                response.sendRedirect("login.html");
            }
        } catch (SQLException ex) {
            log("updateServlet_SQlEx" + ex.getMessage());
        } catch (NamingException ex) {
            log("updateServlet_NamingEx" + ex.getMessage());
        } finally {
            out.close();
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (NamingException ex) {
            Logger.getLogger(updateServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(updateServlet.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (NamingException ex) {
            Logger.getLogger(updateServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(updateServlet.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
