/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.swing.JOptionPane;

/**
 *
 * @author TTP
 */
public class ProcessServlet extends HttpServlet {

    private final String loginPage = "login.jsp";
    private final String loginServlet = "LoginServlet";
    private final String searchServlet = "SearchServlet";
    private final String showAllServlet = "LoadAllServlet";
    private final String loadCategoryServlet = "LoadCategoryServlet";
    private final String updateCategoryServlet = "UpdateCateServlet";
    private final String requestPage = "request.jsp";
    private final String reportServlet = "ReportServlet";
    private final String filterServlet = "FilterServlet";
    private final String finishServlet = "FinishServlet";
    private final String logoutServlet = "LogoutServlet";

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
            String btnAction = request.getParameter("btnAction");
            String url = loginPage;
            if (btnAction == null) {
                
            } else if (btnAction.equals("Login")) {
                url = loginServlet;
            } else if (btnAction.equals("Logout")) {
                url = logoutServlet;
            } else if (btnAction.equals("Search")) {
                url = searchServlet;
            } else if (btnAction.equals("Show All")) {
                url = showAllServlet;
            } else if (btnAction.equals("Change")) {
                url = loadCategoryServlet;
            } else if (btnAction.equals("Request")) {
                url = requestPage;
            } else if (btnAction.equals("Save")) {
                url = updateCategoryServlet;
            } else if (btnAction.equals("Report")) {
                url = reportServlet;
            } else if (btnAction.equals("Filter")) {
                url = filterServlet;
            } else if (btnAction.equals("Finish")) {
                url = finishServlet;
            }

            RequestDispatcher rd = request.getRequestDispatcher(url);
            rd.forward(request, response);
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
