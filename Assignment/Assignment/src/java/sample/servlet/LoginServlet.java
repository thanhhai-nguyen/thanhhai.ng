/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import javax.naming.NamingException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import sample.tbl_account.tbl_accountDAO;
import sample.tbl_account.tbl_accountDTO;

/**
 *
 * @author TTP
 */
public class LoginServlet extends HttpServlet {

    private final String loginPage = "login.jsp";
    private final String managerPage = "manager.jsp";
    private final String staffPage = "staff.jsp";
    private final String invalidPage = "invalid.html";
    private final String accessDenied = "accessDenied.html";

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
            String url = loginPage;
            String username = request.getParameter("txtUsername");
            String password = request.getParameter("txtPassword");

            tbl_accountDAO dao = new tbl_accountDAO();
            boolean valid = dao.checkLogin(username, password);
            if (valid) {
                int role = dao.getRole(username);
                if (role == 1) {
                    url = staffPage;
                    tbl_accountDTO dto = new tbl_accountDTO(username, role);
                    HttpSession session = request.getSession(true);
                    session.setAttribute("ACCOUNT", dto);
                } else if (role == 3) {
                    url = managerPage;
                    tbl_accountDTO dto = new tbl_accountDTO(username, role);
                    HttpSession session = request.getSession(true);
                    session.setAttribute("ACCOUNT", dto);
                } else {
                    url = accessDenied;
                }
            } else {
                url = invalidPage;
            }
            response.sendRedirect(url);
        } catch (NamingException ex) {
            log("NamingException_LoginServlet " + ex.getMessage());
        } catch (SQLException ex) {
            log("SQLException_LoginServlet " + ex.getMessage());
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
