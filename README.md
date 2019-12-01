# Bodega
Proyecto de manejo de inventario en una Bodega

---- Revisión 1/12/19 ----

* Agregado Crystal Report
* Agregado Reportes de Productos y Transacciones
* Agregada Forma Ingreso 

----Cambios Generales ----

* Solo una instancia para las Formas de Mantenimiento y Transacción

---- Cambios en Mantenimiento -----
* ID del producto ahora esta deshabilitado (No es editable)
* Agregado un botón de Editar, para mejor control en los productos
* Datagrid es ReadOnly
* Imágenes ahora en Propiedad Zoom en lugar de Streched
* Reparado el botón Guardar no se deshabilitaba después de Cancelar un ingreso.
* Pequeños cambios en el diseño como ventana 
	- Centrado 
	- No resize y no maximizar.
	- TextBox y botones deshabilitados hasta iniciar una acción.

---- Cambios en Transacciones Egreso-----
* Rebuild de la forma en general.
* Agregado campos similares a los videos explicativos
	- Botones agregar y quitar
	- Textbox ID de la transacción, botón activo, combobox fecha
	- Etiqueta ANULADO en caso el pedido sea cancelado
	- Datagrid mejorado con combobox en los productos
* Cambios en la apariencia
	-Centrado 
	-No resize y no maximizar.
	-TextBox y botones deshabilitados hasta iniciar una acción.
	-Datagrid Readonly hasta iniciar una acción.
	

---- Detalles a mejorar ------
* Imagen desaparece cuando cambia la descripción, precio, etc.
* Data grid no muestra las categorías, probablemente por falta de conexión entre tablas.
* Crear función ubicacionesBL pare mejor control de zonas.
* Evitar que las facturas pierdan el nombre de los productos si estos son eliminados del almacén.
* Ubicación del primer producto se iguala a 1 cuando se navega en los datos, No se editan los datos, es un error meramente visual.
* Al tabular en la forma Ingresar Producto el orden es caótico.
* Necesita validación de productos insuficientes en caso falten para hacer transacción.
* Mostrar ubicación del producto en las facturas
* Producto no debería aparecer o poder editarse en la factura cuando producto no está Activo
* Falta editar Onload en la form Transacción Ingreso además de otros detalles estéticos.

