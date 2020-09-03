@Code
    ViewData("Title") = "Productos"
End Code

<h2>@ViewData("Title").</h2>
<h3>@ViewData("Message")</h3>

<p>@Html.ActionLink("ABM de Productos", "ABMProductos", "Home")</p>