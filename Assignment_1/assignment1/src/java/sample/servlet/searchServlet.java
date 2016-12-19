/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sample.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
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
import sample.tbl_order.tbl_orderDAO;

/**
 *
 * @author TTP
 */
public class searchServlet extends HttpServlet {

    private final String search = "search.jsp";
    private final String login = "login.html";

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
            throws ServletException, IOException, ParseException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String url = login;
        try {
            HttpSession session = request.getSession(false);

            if (session != null) {
                String dateFrom = request.getParameter("txtdateFrom");
                String dateTo = request.getParameter("txtdateTo");
                url = search;
                if (!dateFrom.isEmpty() && !dateTo.isEmpty()) {

                    //Check validation of Date
                    DateFormat format = new SimpleDateFormat("yyyy-MM-dd");
                    format.setLenient(false);
                    Date date1 = format.parse(request.getParameter("txtdateFrom").trim());
                    Date date2 = format.parse(request.getParameter("txtdateTo").trim());
                    // check valid date
                    long d = date1.getTime() - date2.getTime();
                    if (d <= 0) {
                        String customerID = (String) session.getAttribute("CUSTOMERID");
                        tbl_orderDAO dao = new tbl_orderDAO();
                        dao.searchByDate(dateFrom, dateTo, customerID);
                        List result = dao.getItems();
                        request.setAttribute("RESULT", result);
                    } else {
                        request.setAttribute("DAYERROR", "Day From phải bé hơn Day To");
                    }

                }

            }
        } catch (SQLException ex) {
            log("searchServlet_sql" + ex.getMessage());
        } catch (NamingException ex) {
            log("searchServlet_naming" + ex.getMessage());
        } catch (ParseException ex) {
            request.setAttribute("DAYERROR", " Ngày nhập không tồn tại !!!!");
            log("searchServlet_parse" + ex.getMessage());
        } finally {
            RequestDispatcher rd = request.getRequestDispatcher(url);
            rd.forward(request, response);
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
        } catch (ParseException ex) {
            Logger.getLogger(searchServlet.class.getName()).log(Level.SEVERE, null, ex);
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
        } catch (ParseException ex) {
            Logger.getLogger(searchServlet.class.getName()).log(Level.SEVERE, null, ex);
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
