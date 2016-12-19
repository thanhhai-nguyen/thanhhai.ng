/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import javax.naming.NamingException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.swing.JOptionPane;
import sample.tbl_maintenance.tbl_maintenanceDAO;
import sample.tbl_maintenance.tbl_maintenanceDTO;

/**
 *
 * @author TTP
 */
public class FilterServlet extends HttpServlet {

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
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        try {
            String value = request.getParameter("txtDate");
            String url = staffPage;

            // default date
            if (value.equals("")) {
                Date nowDay = new Date();
                SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
                value = date.format(nowDay);
            }

            //create list
            if (value != null) {
                if (!value.equals("")) {
                    String year = value.substring(0, 4);
                    String month = value.substring(5, 7);
                    String day = value.substring(8, 10);
                    if (year.matches("\\d+{4}")) {
                        if (month.matches("\\d+{2}")) {
                            if (day.matches("\\d+{2}")) {
                                tbl_maintenanceDAO dao = new tbl_maintenanceDAO();
                                List<tbl_maintenanceDTO> result = dao.searchDate(value);
                                request.setAttribute("FIX", result);
                            }
                        }
                    } else {
                        JOptionPane.showMessageDialog(null, "Date input not valid");
                    }
                }
            }
            RequestDispatcher rd = request.getRequestDispatcher(url);
            rd.forward(request, response);
        } catch (NamingException e) {
            log("NamingException_DateFilterServlet: " + e.getMessage());
        } catch (SQLException e) {
            log("SQLException_DateFilterServlet: " + e.getMessage());
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
