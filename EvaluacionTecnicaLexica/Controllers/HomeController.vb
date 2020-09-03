Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Categorias() As ActionResult
        ViewData("Message") = "Categorias de productos"

        Return View()
    End Function

    Function ABMCategorias() As ActionResult
        ViewData("Message") = "ABM de Categorias"

        Return View()
    End Function
    Function ABMProductos() As ActionResult
        ViewData("Message") = "ABM de Productos"

        Return View()
    End Function
    Function Productos() As ActionResult
        ViewData("Message") = "Listado de Productos"

        Return View()
    End Function
    Function ABMBodegas() As ActionResult
        ViewData("Message") = "AMB de Bodegas"

        Return View()
    End Function
    Function Bodegas() As ActionResult
        ViewData("Message") = "Bodegas"

        Return View()
    End Function
    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
