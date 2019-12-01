# Bodega
Proyecto de manejo de inventario en una Bodega
----Revision 1/12/19----

* Agregado Crystal Report
* Agregado Reportes de Productos y Transacciones
* Agregada Forma Ingreso
----Cambios Generales----

*Solo una instancia para las Formas de Mantenimiento y Transaccion

----Cambios en Mantenimiento-----
*ID del producto ahora esta deshabilitado (No es editable)
*Agregado un boton de Editar, para mejor control en los productos
*Datagrid es ReadOnly
*Imagenes ahora en Propiedad Zoom en lugar de Streched
*Reparado el boton Guardar no se desabilitaba despues de Cancelar un ingreso.
*Pequeños cambios en el diseño como ventana 
	-Centrado 
	-No resize y no maximizar.
	-TextBox y botones deshabilitados hasta iniciar una accion.

----Cambios en Transacciones Egreso-----
*Rebuild de la forma en general.
*Agregado campos similares a los videos explicativos
	-Botones agregar y quitar
	-Textbox ID de la transaccion, boton activo, combobox fecha
	-Etiqueta ANULADO en caso el pedido sea cancelado
	-Datagrid mejorado con combobox en los productos
*Cambios en la apariencia
	-Centrado 
	-No resize y no maximizar.
	-TextBox y botones deshabilitados hasta iniciar una accion.
	-Datagrid Readonly hasta iniciar una accion.
	

----Detalles a mejorar------
*Imagen desaparece cuando cambia la descripcion, precio, etc.
*Data grid no muestra las categorias, prob por falta de conexion entre tablas.
*Crear funcion ubicacionesBL pare mejor control de zonas.
*Evitar que las facturas pierdan el nombre de los productos si estos son eliminados del almacen.
*Ubicacion del primer producto se iguala a 1 cuando se navega en los datos, No se editan los datos, es un error meramente visual.
*Al tabular en la forma Ingresar Producto el orden es caotico.
*Necesita validacion de productos insuficientes en caso falten para hacer transaccion.
*Mostra ubicacion del producto en las facturas
*Producto no deberia aparecer o poder editarse en la factura cuando producto no esta Activo
*Falta editar Onload en la form Transaccion Ingreso ademas de otros detalles esteticos.
