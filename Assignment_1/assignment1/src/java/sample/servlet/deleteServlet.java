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
import sample.product.tbl_productDAO;
import sample.tbl_order.tbl_orderDAO;
import sample.tbl_orderDetail.tbl_orderDetailDAO;

/**
 *
 * @author TTP
 */
public class deleteServlet extends HttpServlet {

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
            if (session != null) {
                String ID = request.getParameter("ID");
                String orderID = request.getParameter("orderID");
                String quantity = request.getParameter("quantity");
                String productID = request.getParameter("productID");
                // delete orderDetail
                tbl_orderDetailDAO dao = new tbl_orderDetailDAO();
                dao.deleteItem(Integer.parseInt(ID));                
                // total left
                float realTotal = dao.searchForTotal(orderID);
                // update tbl_order
                tbl_orderDAO orderDAO = new tbl_orderDAO();
                orderDAO.updateRecord(orderID, realTotal);
                // update tbl_product
                tbl_productDAO productDAO = new tbl_productDAO();
                        // table Product Quantity
                int tableQuantity = productDAO.searchQuantity(productID);
                        // new update Quantity
                int productQuantity = tableQuantity + Integer.parseInt(quantity);
                productDAO.updateQuantity(productID, productQuantity);
                        // check total
                float result = orderDAO.checkQuantity(orderID);
                // delete order record
                if(result == 0){
                orderDAO.deleteRecord(request.getParameter("orderID"));
                    String url = "ProcessServlet?btAction=Search"
                            + "&txtdateFrom"
                            + request.getParameter("txtdateFrom")
                            + "txtdateTo";
                    RequestDispatcher rd = request.getRequestDispatcher(url);
                    rd.forward(request, response);
                }
                String url = "ProcessServlet?btAction=detail"
                        + "&orderID="
                        + request.getParameter("orderID")
                        + "&txtdateFrom"
                        + request.getParameter("txtdateFrom")
                        + "txtdateTo"
                        + request.getParameter("txtdateTo")
                        + "&Date="
                        + request.getParameter("Date")
                        + "&Customer="
                        + request.getParameter("Customer")
                        + "&phone="
                        + request.getParameter("phone")
                        + "&address="
                        + request.getParameter("address")
                        + "&total="
                        + realTotal;
                
                RequestDispatcher rd = request.getRequestDispatcher(url);
                rd.forward(request, response);
                
            }
        } catch (NamingException ex) {
            log("deleteServlet_NamingEx" + ex.getMessage());
        } catch (SQLException ex) {
            log("deleteServlet_SQLEx" + ex.getMessage());
                        
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
            Logger.getLogger(deleteServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(deleteServlet.class.getName()).log(Level.SEVERE, null, ex);
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
            Logger.getLogger(deleteServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(deleteServlet.class.getName()).log(Level.SEVERE, null, ex);
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
