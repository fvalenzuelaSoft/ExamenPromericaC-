
/*A*/
/*Escriba la consulta en SQL que devuelva el nombre del proyecto y sus productos correspondientes del proyecto Premia cuyo código es 1*/
SELECT PR.Nombre AS Proyecto,PRD.Descrpcion AS Producto
FROM Proyecto PRY
INNER JOIN Producto_Proyecto PRP ON PRP.Proyecto = PRY.Proyecto
INNER JOIN Producto PRD ON PRD.Producto = PRP.Producto
WHERE PR.Proyecto = 1

/*B*/
/*Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen.*/
SELECT MEN.cod_mensaje AS CodigoMensaje,
	   TIP.Nombre AS TipoMensaje,
	   PRY.nombre AS NombreProyecto,
	   PRD.descripcion AS NombreProducto
FROM Producto_Proyecto PRP 
INNER JOIN Mensaje MEN ON MEN.proyecto = PRP.proyecto AND MEN.producto = PRP.producto
INNER JOIN Proyecto AS PRY ON PRY.Proyecto = MEN.Proyecto
INNER JOIN Producto PRD ON PRD.producto = MEN.producto
INNER JOIN Formato_Mensaje FM ON MEN.cod_formato = FM.cod_formato
INNER JOIN Tipo_Informacion TIP ON FM.cod_tipo_Informacion = TIP.cod_tipo_informacion

/*C*/
/*Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen. 
  Pero si el mensaje está en todos los productos de un proyecto, 
  en lugar de mostrar cada producto, debe mostrar el nombre del proyecto y un solo producto que diga “TODOS”.*/  
DECLARE @TblMensaje TABLE(cod_mensaje SMALLINT, Proyecto SMALLINT, NombreProyecto VARCHAR(25),Producto SMALLINT,NombreProducto VARCHAR(25));

SELECT MEN.cod_mensaje AS CodigoMensaje,
	   PRP.Proyecto,
	   PRY.nombre AS NombreProyecto,
	   PRP.producto AS Producto,
	   PRD.descripcion AS NombreProducto
INTO @TblMensaje	
FROM Producto_Proyecto PRP 
LEFT JOIN Mensaje MEN ON MEN.proyecto = PRP.proyecto AND MEN.producto = PRP.producto
LEFT JOIN Proyecto AS PRY ON PRY.Proyecto = MEN.Proyecto
LEFT JOIN Producto PRD ON PRD.producto = MEN.producto

UPDATE X SET NombreProducto = 'TODOS' 
FROM @TblMensaje AS X 
WHERE NOT EXISTS (
				  SELECT DISTINCT Proyecto 
				  FROM @TblMensaje AS B 
				  WHERE X.Proyecto = B.Proyecto 
					AND CodigoMensaje IS NULL
			      )


SELECT DISTINCT NombreProyecto, NombreProducto AS Producto  
FROM @TblMensaje WHERE CodigoMensaje IS NOT NULL

