﻿@Code
    ViewData("Title") = "Gestion de Productos"
End Code

<div class="row">
    <div class="col-md-4">
        <h2>Listado de productos</h2>
        <p>
          Listado de productos..</p>
        <p>@Html.ActionLink("Ver listado de Productos", "Productos", "Home")</p>
    </div>
    <div class="col-md-4">
        <h2>Listado de Categorias</h2>
        <p>Listado de Categorias...</p>
        <p>@Html.ActionLink("Ver listado de Categorias", "Categorias", "Home")</p>
    </div>
    <div class="col-md-4">
        <h2>Listado de Bodegas</h2>
        <p>Listado de Bodegas...</p>
        <p> @Html.ActionLink("Ver listado de Bodegas", "Bodegas", "Home")</p>
    </div>
</div>
