﻿using ProjectPSD.Controller;
using ProjectPSD.Factory;
using ProjectPSD.Handler;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected static List<Carts> carts = new List<Carts>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
                carts = (List<Carts>)Session["cart"];
                cartProduct.DataSource = CartRepository.getCurrUserCarts((int)Session["userId"]);
                cartProduct.DataBind();
                GrandTotal.Text = CartRepository.GrandTotal((int)Session["userId"]).ToString();
            }
        }

        protected void onUpdate_Click(object sender, EventArgs e)
        {
            Button updateCart = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)updateCart.NamingContainer;
            string cartsId = cartProduct.Rows[selectedRow.RowIndex].Cells[1].Text;
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("UpdateCart.aspx?id=" + id);
        }

        protected void onDelete_Click(object sender, EventArgs e)
        {
            Button deleteCart = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)deleteCart.NamingContainer;
            string cartsId = cartProduct.Rows[selectedRow.RowIndex].Cells[1].Text;
            int cartId = toInt(cartsId);
            CartRepository.deleteCart(cartId);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["userId"].ToString());
            Carts checkout = CartRepository.getCartData((int)Session["userId"]);
            String paymentType;
            int paymentTypesID = paymentTypeID.SelectedIndex;

            try
            {
                paymentType = paymentTypeID.SelectedItem.Value;
            }
            catch
            {
                paymentType = "";
            }
            if (checkout == null)
            {
                errMsg.Text = "Cannot Check out, the cart is empty";
            }
            else if (paymentTypeID.SelectedIndex < 0)
            {
                errMsg.Text = "Payment Type must be selected";
            }
            else
            {
                errMsg.Text = "PaymentTypeIndex: " + paymentTypesID;
                paymentTypesID += 1;
                /*TransactionController.CheckOut(userId, paymentTypesID, carts);
                Response.Redirect("Home.aspx");*/
            }
        }

        protected int toInt(String s)
        {
            int number;
            bool isParsable = Int32.TryParse(s, out number);
            if (isParsable)
                return (number);
            else
                return (0);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}