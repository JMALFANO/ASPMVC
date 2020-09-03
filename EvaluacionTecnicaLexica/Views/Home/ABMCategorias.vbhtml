@Code
    ViewData("Title") = "ABMCategorias"
End Code


<div class="row">
    <div class="col-md-4">

        <h2>@ViewData("Title").</h2>
        <h3>@ViewData("Message")</h3>

    </div>
    <div class="col-md-4">

       
        
       <form>
            <input type="text" name="nombre">
            <input type="submit" value="Submit">
        </form>



    </div>
    <div class="col-md-4">

    </div>
</div>

<p>@Html.ActionLink("Inicio", "Index", "Home")</p>

