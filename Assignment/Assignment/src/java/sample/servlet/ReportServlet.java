/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.Date;
import javax.naming.NamingException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.swing.JOptionPane;
import sample.tbl_account.tbl_accountDTO;
import sample.tbl_maintenance.tbl_maintenanceDAO;
import sample.tbl_room.tbl_roomReportError;

/**
 *
 * @author TTP
 */
public class ReportServlet extends HttpServlet {

    private final String requestPage = "request.jsp";

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
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        try {
            String txtReason = request.getParameter("txtReason").trim();
            String url = "ProcessServlet?btnAction=Show All";
            boolean Err = false;
            
            tbl_roomReportError error= new tbl_roomReportError();
            if (txtReason.equals("")) {
                Err = true;
                error.setEmptyField("Reason must be fill");
            } else if (txtReason.length() > 250) {
                Err = true;
                error.setTooLongField("Field must contain < 250 character");
            }if(Err){
                request.setAttribute("ERROR", error);
            } 
            else {
                
                String roomID = request.getParameter("roomID");

                // get user request
                HttpSession session = request.getSession();
                tbl_accountDTO account = (tbl_accountDTO) session.getAttribute("ACCOUNT");
                String requestUser = account.getUsername();
                // date form SQL
                Date date = new Date();
                java.sql.Date requestDate = new java.sql.Date(date.getTime());
                tbl_maintenanceDAO dao = new tbl_maintenanceDAO();
                boolean success = dao.createReport(requestUser, roomID, txtReason, requestDate);
                if (success) {
                    url = "ProcessServlet?btnAction=Show All";
                }
            }
            response.sendRedirect(url);
        } catch (NamingException ex) {
            log("NamingException_CreateReportServlet: " + ex.getMessage());
        } catch (SQLException ex) {
            log("SQLException_CreateReportServlet: " + ex.getMessage());
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
        processRequest(request, response);
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
        processRequest(request, response);
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
