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
import sample.account.tbl_accountDAO;
import sample.error.RegistrationError;
import sample.tbl_order.tbl_orderDAO;

/**
 *
 * @author TTP
 */
public class signupServlet extends HttpServlet {

    private final String errorPage = "register.jsp";
    private final String loginPage = "login.html";

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
            throws ServletException, IOException, NamingException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String username = request.getParameter("txtUsernameNew");
        String password = request.getParameter("txtPasswordNew");
        String confirm = request.getParameter("txtPasswordConfirm");
        String fullname = request.getParameter("txtFullnameNew");
        String email = request.getParameter("txtEmailNew");

        RegistrationError error = new RegistrationError();
        boolean Err = false;
        String url = errorPage;
        try {

            if (username.trim().length() < 1 || username.trim().length() > 10) {
                Err = true;
                error.setUsernameLengthErr("Username co kich thuoc < 10 ky tu!!!");

            }
            if (password.trim().length() < 3 || password.trim().length() > 20) {
                Err = true;
                error.setPasswordLengthErr("Password co kich thuoc < 10 ky tu!!!");

            } else if (!confirm.trim().equals(password.trim())) {
                Err = true;
                error.setConfirmNotMatch("Confirm và password khác nhau");

            }
            if (fullname.trim().length() < 3 || fullname.trim().length() > 50) {
                Err = true;
                error.setFullNameLengthErr("Fullname co kich thuoc < 50 ky tu!!!");

            }
            if (Err) {
                request.setAttribute("SIGNUPERROR", error);

            } else {
                tbl_accountDAO dao = new tbl_accountDAO();
                boolean result = dao.insertRecord(username, password, fullname, email);
                if (result) {
                    url = loginPage;
                }
            }

        } catch (ClassNotFoundException e) {
            log("ClassNotFoundException_signupServlet" + e.getMessage());
        } catch (SQLException e) {
            log("SQLException_signupServlet" + e.getMessage());
            //username exist 
            if (e.getMessage().contains("PRIMARY KEY")) {
                error.setUsernameIsExisted(username + " đã tồn tại !!!");
                request.setAttribute("SIGNUPERROR", error);
            }
            //email exist
            if (e.getMessage().contains("UNIQUE KEY")){
                error.setEmailIsExisted(email + " đã được đăng kí !!!!");
                request.setAttribute("SIGNUPERROR", error);
            }
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
        } catch (NamingException ex) {
            Logger.getLogger(signupServlet.class.getName()).log(Level.SEVERE, null, ex);
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
            Logger.getLogger(signupServlet.class.getName()).log(Level.SEVERE, null, ex);
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
