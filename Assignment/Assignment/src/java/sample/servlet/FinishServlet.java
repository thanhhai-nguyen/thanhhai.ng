/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.NamingException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import sample.tbl_account.tbl_accountDTO;
import sample.tbl_maintenance.tbl_maintenanceDAO;
import sample.tbl_maintenance.tbl_maintenanceDTO;

/**
 *
 * @author TTP
 */
public class FinishServlet extends HttpServlet {

    private final String staffPage = "staff.jsp";

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
            throws ServletException, IOException, SQLException, NamingException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        try {
            HttpSession session = request.getSession(false);
            tbl_accountDTO account = (tbl_accountDTO) session.getAttribute("ACCOUNT");
            String username = account.getUsername();

            String[] IdArr = request.getParameterValues("txtId");
            String[] mends = request.getParameterValues("txtMend");
            String[] costs = request.getParameterValues("txtCost");
            int length = IdArr.length;

            tbl_maintenanceDAO dao = new tbl_maintenanceDAO();
            for (int i = 0; i < length; i++) {
                String mend = mends[i];
                float cost = Float.parseFloat(costs[i]);
                int id = Integer.parseInt(IdArr[i]);
                System.out.println("mend: " + mend + " cost: " + cost + " id: " + id + " username: " + username);
                dao.updateReport(username, id, mend, cost);

            }
            String search = request.getParameter("txtSearchDate");
            String url = "ProcessServlet?btnAction=Filter&txtDate=" + search;
            response.sendRedirect(url);

        } catch (SQLException e) {
            log("SQLException_FinishServlet" + e.getMessage());
        } catch (NamingException e) {
            log("NamingException_FinishServlet" + e.getMessage());
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
        } catch (SQLException ex) {
            Logger.getLogger(FinishServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (NamingException ex) {
            Logger.getLogger(FinishServlet.class.getName()).log(Level.SEVERE, null, ex);
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
        } catch (SQLException ex) {
            Logger.getLogger(FinishServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (NamingException ex) {
            Logger.getLogger(FinishServlet.class.getName()).log(Level.SEVERE, null, ex);
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
