﻿Imports System.Data.SqlClient

Module Permisos
    Dim f As New Funciones.Funciones
    Dim Existe As Integer
    Dim Sql As String
    Dim PermisoBD(350, 2) As String
    Dim TotalPermiso As Integer = 279
    Dim CantPermisos As Integer
    Private sqlc As New SqlConnection
    Private myTrans As SqlTransaction
    Private ser As New BDConexión.BDConexion
    Private cmd As New SqlCommand

    Public Sub ExistePermiso()
        'Primero Armamos el Array con la lista de todos los permisos
        ListarPermisos()
        'Verificamos la Cantidad de Permisos en la BD Local
        CantPermisos = f.CantidadRegistro("Permiso_id", "PERMISOS")

        If CantPermisos < TotalPermiso Then  'en caso de ser menor debemos recorrer el arrary para cargar los permisos faltantes
            For i = 0 To TotalPermiso - 1
                Existe = f.FuncionConsultaDecimal("Permiso_id", "PERMISOS", "Permiso_id", PermisoBD(i, 0))

                If Existe = 0 Then 'insertamos en la base de datos
                    ser.Abrir(sqlc)
                    myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

                    cmd.Connection = sqlc
                    cmd.Transaction = myTrans

                    Sql = ""
                    Sql = "INSERT INTO PERMISOS(Permiso_id,Modulo_id,Pregunta)VALUES(" & PermisoBD(i, 0) & "," & PermisoBD(i, 1) & ",'" & PermisoBD(i, 2) & "')"
                    cmd.CommandText = Sql
                    cmd.ExecuteNonQuery()
                    myTrans.Commit()
                    sqlc.Close()
                End If
            Next
        End If
    End Sub

    Public Sub ListarPermisos()
        PermisoBD = {{1, 19, "Empresa:Puede Abrir?"},
                     {2, 19, "Empresa:Puede Guardar?"},
                     {3, 2, "Abrir la ventana de Proveedores"},
                     {4, 2, "Crear un Proveedor Nuevo"},
                     {5, 2, "Eliminar la Ficha de Proveedores"},
                     {6, 2, "Modificar la Ficha de Proveedores"},
                     {7, 7, "Abrir la ventana de Clientes"},
                     {8, 7, "Crear un Cliente Nuevo"},
                     {9, 7, "Eliminar la Ficha de Clientes"},
                     {10, 7, "Modificar la Ficha de Clientes"},
                     {11, 4, "Abrir la ventana de Pcs"},
                     {12, 4, "Cargar un Pcs "},
                     {13, 4, "Eliminar un Pcs "},
                     {14, 4, "Ver Cta. Cte. del Proveedor"},
                     {15, 4, "Ver Movimiento de Caja"},
                     {16, 5, "Crear una Apertura de Caja"},
                     {17, 5, "Crear un Cierre de Caja"},
                     {18, 5, "Hacer Ajustes de Movimiento a la Caja"},
                     {19, 3, "Abrir la ventana de Compras"},
                     {20, 3, "Crear una Compra"},
                     {21, 3, "Eliminar una Orden de Compra"},
                     {22, 3, "Modificar la Compra"},
                     {23, 3, "Aprobar una Compra"},
                     {24, 3, "Anular la Compra"},
                     {25, 8, "Abrir la ventana de Ventas"},
                     {26, 8, "Crear una Venta"},
                     {27, 8, "Eliminar una Venta Presupuestada"},
                     {28, 8, "Modificar una Venta"},
                     {29, 8, "Aprobar una Venta"},
                     {30, 8, "Anular una Venta"},
                     {31, 8, "Permitir vender a Credito"},
                     {34, 8, "Vender mas que el Limite de Credito"},
                     {35, 7, "Modificar Datos Financieros del Cliente"},
                     {36, 10, "Abrir Cobros"},
                     {37, 10, "Cargar un cobro"},
                     {38, 10, "Eliminar Cobros"},
                     {39, 10, "Ver Cuenta Corriente del Cliente"},
                     {40, 10, "Ver Movimiento de Caja"},
                     {41, 8, "Cargar Numero de Factura Manual"},
                     {42, 11, "Abrir la Ventana  Devoluciones"},
                     {43, 11, "Crear una Devolucio"},
                     {44, 11, "Modificar una Devolucion"},
                     {45, 11, "Eliminar una Devolucion"},
                     {46, 11, "Aprobar una Devolucion"},
                     {47, 11, "Anular una Devolucion"},
                     {48, 11, "Devolver Sin Generar Nota de Credito"},
                     {49, 16, "Abrir la Ventana de Usuarios"},
                     {50, 16, "Crear Nuevos Usuarios"},
                     {51, 16, "Modificar Datos de Usuarios"},
                     {52, 16, "Eliminar Usuario"},
                     {53, 16, "Modificar Permisos"},
                     {54, 12, "Abrir Ventana  de Productos"},
                     {55, 12, "Crear Nuevo Producto"},
                     {56, 12, "Eliminar un Producto"},
                     {57, 12, "Modificar Datos de Producto"},
                     {58, 12, "Abrir Ventana de Codi  de Barra"},
                     {59, 13, "Abrir Venta de  Inventario"},
                     {60, 19, "Stock Inicial: Puede Abrir?"},
                     {61, 19, "Banco:Puede Abrir?"},
                     {62, 19, "Cajas y Cobradores:Puede Abrir?"},
                     {63, 19, "Cajas y Cobradores:Puede Crear?"},
                     {64, 19, "Cajas y Cobradores :Puede Modificar?"},
                     {65, 19, "Cajas y Cobradores: Puede Eliminar?"},
                     {66, 19, "Clasificacion de Productos:Puede abrir?"},
                     {67, 19, "Clasificacion de Productos:Puede crear Nuevas cate rias?"},
                     {68, 19, "Clasificacion de Productos:Puede Eliminar?"},
                     {69, 19, "Clasificacion de Productos:Puede Modificar cate rias?"},
                     {70, 19, "Pais y Ciudad: Puede Abrir?"},
                     {71, 19, "Pais y Ciudad:Puede Crear?"},
                     {72, 19, "Pais y Ciudad:Puede Eliminar?"},
                     {73, 19, "Pais y Ciudad:Puede Modificar?"},
                     {74, 19, "Unidad de Medida:Puede Abrir?"},
                     {75, 19, "Unidad de Medida:Puede Crear Nuevo?"},
                     {76, 19, "Unidad de Medida:Puede Eliminar?"},
                     {77, 19, "Unidad de Medida:Puede Guardar?"},
                     {78, 19, "Unidad de Medida:Puede Modificar?"},
                     {79, 19, "Rango de Comprobantes:Puede Abrir?"},
                     {80, 19, "Rango de Comprobantes:Puede Guardar?"},
                     {81, 19, "Rango de Comprobantes:Puede Eliminar?"},
                     {82, 19, "Rango de Comprobantes:Puede Modificar?"},
                     {83, 19, "Rango de Comprobantes:Puede Crear Nuevo?"},
                     {84, 19, "Rango de Comprobantes:Puede Imprimir?"},
                     {85, 19, "Vendedores y Supervisores:Puede Abrir?"},
                     {86, 19, "Vendedores y Supervisores:Puede Crear Nuevo?"},
                     {87, 19, "Vendedores  y Supervisores:Puede Eliminar?"},
                     {88, 19, "Vendedores y Supervisores:Puede Modificar?"},
                     {89, 19, "Vendedores y Supervisores:Puede Guardar?"},
                     {90, 19, "Monedas:Puede Abrir?"},
                     {91, 19, "Monedas:Puede Crear?"},
                     {92, 19, "Monedas:Puede Elminar?"},
                     {93, 19, "Monedas:Puede Guardar?"},
                     {106, 19, "Tipo de Comprobantes:Puede Eliminar?"},
                     {107, 19, "Tipo de Comprobantes:Puede Modificar?"},
                     {108, 19, "Tipo de Comporbante:Puede Guardar?"},
                     {109, 19, "Serrvidor de Correos:Puede Abrir?"},
                     {110, 19, "Servidor de Correos:Puede Crear Nuevo?"},
                     {111, 19, "Servidor de Correos:Puede Eliminar?"},
                     {94, 19, "Monedas:Puede Modificar?"},
                     {95, 19, "Tarjeta de Credito:Puede Abrir?"},
                     {96, 19, "Tarjeta  de Credito:Puede Crear Nuevo?"},
                     {97, 19, "Tarjeta de Credito:Puede Eliminar?"},
                     {98, 19, "Tarjeta de Credito:Puede Modificar?"},
                     {99, 19, "Tarjeta de Credito:Puede Guardar?"},
                     {100, 19, "Tipo de Clientes:Puede Abrir?"},
                     {101, 19, "Tipo de Clientes:Puede Crear?"},
                     {102, 19, "Tipo de Clientes:Puede Eliminar?"},
                     {103, 19, "Tipo de Clientes:Puede Modificar?"},
                     {104, 19, "Tipo de Comprobantes:Puede Abrir?"},
                     {105, 19, "Tipo de Comprobantes:Puede Crear Nuevo?"},
                     {112, 19, "Servidor de Correos:Puede Guardar"},
                     {113, 19, "Sucursales y Depositos:Puede Abrir?"},
                     {114, 19, "Sucursales y Depositos:Puede Eliminar?"},
                     {115, 19, "Sucursales y Depositos:Puede Modificar?"},
                     {116, 19, "Sucursales y Depositos:Puede Guardar?"},
                     {117, 19, "Sucursales y Depositos:Puede Crear Nuevo?"},
                     {118, 19, "Registrar Modulo:Puede Abrir?"},
                     {119, 19, "Centro de Costo:Puede Abrir?"},
                     {120, 19, "Centro de Costo:Puede Crear Nuevo?"},
                     {121, 19, "Centro de Costo:Puede Eliminar?"},
                     {122, 19, "Centro de Costo:Puede Modificar?"},
                     {123, 19, "Metas:Puede Abrir?"},
                     {124, 19, "Metas:Puede Crear Nuevo?"},
                     {125, 19, "Metas:Puede Eliminar?"},
                     {126, 19, "Metas:Puede Modificar?"},
                     {127, 19, "Eventos:Puede Abrir?"},
                     {128, 19, "Eventos:Puede Crear Nuevo?"},
                     {129, 19, "Eventos:Puede Eliminar?"},
                     {130, 19, "Eventos:Puede  Modificar?"},
                     {131, 19, "Banco:Puede Crear Nuevos Registros"},
                     {132, 19, "Banco:Puede Eliminar?"},
                     {133, 19, "Banco:Puede Modificar?"},
                     {134, 19, "Importar y Exportar Datos:Puede Abrir?"},
                     {135, 19, "Impotar y Exportar Datos:Puede Cargar grilla?"},
                     {136, 5, "Puede Recibir y Pagar?"},
                     {137, 5, "Puede Abrir la ventana Acceso a Cajero?"},
                     {138, 9, "Puede Abrir?"},
                     {140, 17, "Puede Abrir la ventana Auditoria?"},
                     {141, 24, "Puede Abrir la ventana de Backups?"},
                     {142, 19, "Configuraciones:Puede Abrir?"},
                     {143, 18, "Puede Abrir la Ventana de Grupos?"},
                     {144, 18, "Puede Crear Nuevo"},
                     {145, 18, "Puede Eliminar"},
                     {146, 18, "Puede Modificar"},
                     {148, 5, "Puede Abrir la Ventana de Cajas?"},
                     {150, 8, "Ver Reporte de Ventas Pendientes por Zona?"},
                     {151, 8, "Ver  Reporte de Pedidos Pedidos Pendientes por cliente?"},
                     {152, 8, "Ver  Reporte de Ventas por Sucursal?"},
                     {153, 8, "Ver  Reporte de  Lista de Precio?"},
                     {154, 8, "Ver Reporte de Ventas por Cate rias Top{20}?"},
                     {155, 8, "Ver Reporte de Ventas Por Productos Top{20}?"},
                     {156, 8, "Ver Ventas por Producto/Sevicio?"},
                     {157, 8, "Ver  Ventas por Vendedor?"},
                     {158, 8, "Ver Top{20}Productos más Vendidos?"},
                     {159, 8, "Ver  Top{20}Cate rias más Vendidas?"},
                     {160, 8, "Ver  Reporte de Diario de Caja Resumido?"},
                     {161, 8, "Ver  Reporte de Diario de Caja Detallado?"},
                     {162, 8, "Ver  Reporte de Factura a Cobrar?"},
                     {163, 8, "Ver  Reporte de Ventas por Tipo de Cobro?"},
                     {164, 8, "Ver  Reporte de CoGS{Promedio}?"},
                     {165, 8, "Ver  Reporte de CoGS{Ultimo Precio}?"},
                     {166, 8, "Ver  Ventas por Utilidad FIFO?"},
                     {167, 8, "Ver Reporte de Lista de Cliente?"},
                     {168, 8, "Ver Reporte de  Envio Por Zona Articulo?"},
                     {169, 8, "Ver Reporte de CoGS {Promedio Neto}"},
                     {170, 8, "Ver Reporte de Ingresos Vs. Egresos"},
                     {171, 19, "Categoria Proveedor:Puede Abrir?"},
                     {172, 19, "Categoria Proveedor:Puede Crear Nuevos Registros?"},
                     {173, 19, "Categoria Proveddor: Puede Eliminar?"},
                     {174, 19, "Categoria Proveddor:Puede Modificar?"},
                     {175, 19, "Categoria Cliente :Puede Abrir?"},
                     {176, 19, "Categoria Cliente: Puede Crear Nuevos Registros?"},
                     {177, 19, "Categoria Cliente:Puede Eliminar?"},
                     {178, 19, "Categoria Cliente:Puede Modificar?"},
                     {179, 8, "Ver Reporte CoGS Ultimo Precio Neto?"},
                     {180, 8, "Ver Reporte Resumen de Caja?"},
                     {181, 8, "Ver Reporte Cantidad Vendida?"},
                     {182, 8, "Ver Reporte Cantidad Vendida Hoy?"},
                     {183, 8, "Ver Reporte Resumen de Venta?"},
                     {184, 8, "Ver Reporte Ventas Detallado?"},
                     {185, 8, "Ver Reporte Utilidad de Cliente?"},
                     {186, 8, "Ver Reporte Gs.Comprado?"},
                     {187, 8, "Ver Reporte Utilidad por Venta?"},
                     {188, 8, "Ver Reporte Lista de Precio?"},
                     {189, 8, "Ver Reporte BreakEven?"},
                     {190, 8, "Ver Reporte Venta Compra?"},
                     {191, 27, "Puede Abrir Marketing?"},
                     {192, 8, "Puede Re Imprimir Factura con el mismo Nro?"},
                     {193, 8, "Puede Re Imprimir Factura con un Nro Nuevo?"},
                     {194, 26, "Puede Abrir la Ventana de Asientos ?"},
                     {195, 26, "Puede Abrir la ventana de Plantillas?"},
                     {196, 26, "Puede Abrir la ventana de Re-Asentar?"},
                     {197, 26, "Puede Abrir la ventana de Libro de Compra?"},
                     {198, 26, "Puede Abrir la ventana de Libro de Venta?"},
                     {199, 26, "Puede Abrir la ventana de Periodo Fiscal?"},
                     {200, 26, "Puede Abrir la ventana de Plan de Cuentas?"},
                     {201, 8, "Vender mas que Stock? (Permitir Stock Negativo)"},
                     {202, 8, "Ver Reporte Resumen Caja con Iva?"},
                     {203, 19, "Puede Calcular Costos?"},
                     {204, 28, "Carga Produccion:Puede Abrir?"},
                     {205, 28, "Carga Produccion:Puede Crear Nuevo?"},
                     {206, 28, "Carga Produccion:Puede Eliminar?"},
                     {207, 28, "Carga Produccion:Puede Modificar?"},
                     {208, 28, "Carga Produccion:Puede Aprobar?"},
                     {209, 28, "Carga Produccion:Puede Anular?"},
                     {210, 19, "Configuracion PEX:Puede Anular?"},
                     {211, 19, "Configuracion PEX:Puede Modificar?"},
                     {212, 8, "Puede Crear una Factura en Blanco?"},
                     {213, 8, "Puede Duplicar el contenido de una Factura?"},
                     {214, 8, "Puede Modificar el Nro. de una Factura ya aprobada?"},
                     {215, 29, "Abrir la Ventana Devoluciones Compras"},
                     {216, 29, "Crear una Devolucion"},
                     {217, 29, "Modificar una Devolucion"},
                     {218, 29, "Eliminar una Devolucion"},
                     {219, 29, "Aprobar una Devolucion"},
                     {220, 29, "Anular una Devolucion"},
                     {221, 3, "Poder Modificar el Nro de Factura"},
                     {222, 9, "Puede Eliminar un Movimiento?"},
                     {223, 8, "Puede Cambiar el Precio de Venta?"},
                     {224, 8, "Puede Ver Otras Listas de Precios?"},
                     {225, 8, "Puede Eliminar un Detalle de Venta?"},
                     {226, 12, "Modificar Precio de Producto"},
                     {227, 7, "Puede Activar/Desactivar un Cliente"},
                     {228, 28, "Puede Crear uno Nuevo Consumo Interno"},
                     {229, 28, "Puede Modificar los Datos de Consumo Interno"},
                     {230, 28, "Puede Eliminar los Datos de Consumo Interno"},
                     {231, 28, "Puede Abir Consumo Interno"},
                     {232, 3, "Puede Duplicar el Contenido de una Factura?"},
                     {233, 3, "Puede Modificar el Nro. de una Factura ya aprobada?"},
                     {234, 28, "Puede Crear una Nueva Produccion"},
                     {235, 28, "Puede Modificar los Datos de Produccion"},
                     {236, 28, "Puede Eliminar los Datos de Produccion"},
                     {237, 28, "Puede Abir Produccion"},
                     {238, 28, "Puede Crear un Nuevo Fraccionamiento"},
                     {239, 28, "Puede Modificar los Datos de Fraccionamiento"},
                     {240, 28, "Puede Eliminar los Datos de Fraccionamiento"},
                     {241, 28, "Puede Abir Fraccionamiento"},
                     {242, 28, "Puede Crear un Nuevo Ajuste"},
                     {243, 28, "Puede Modificar los Datos de Ajuste"},
                     {244, 28, "Puede Eliminar los Datos de Ajuste"},
                     {245, 28, "Puede Abir Ajuste"},
                     {246, 28, "Puede Crear un Nuevo Combos"},
                     {247, 28, "Puede Modificar los Datos de Combos"},
                     {248, 28, "Puede Eliminar los Datos de Combos"},
                     {249, 28, "Puede Abir Combos"},
                     {250, 28, "Puede Crear un Nuevo Etiquetas/Cajas"},
                     {251, 28, "Puede Modificar los Datos de Etiquetas/Cajas"},
                     {252, 28, "Puede Eliminar los Datos de Etiquetas/Cajas"},
                     {253, 28, "Puede Abir Etiquetas/Cajas"},
                     {254, 11, "Modificar despues de Aprobar una Devolucion"},
                     {255, 8, "Modificar despues de Aprobar una Venta"},
                     {256, 26, "Puede Abrir la Ventana de Asientos de Costo ?"},
                     {257, 26, "Puede Abrir la Ventana de Costos de Productos por Ventas ?"},
                     {258, 3, "Modificar despues de Aprobar una Compra"},
                     {259, 2, "Puede Activar/Desactivar un Proveedor"},
                     {260, 30, "Puede Cambiar el Vendedor?"},
                     {261, 3, "Puede Cambiar el Tipo Iva por Defecto del Producto?"},
                     {262, 12, "Puede ver el Panel de Costo?"},
                     {263, 8, "Puede Importar SEPSA"},
                     {264, 8, "Puede Exportar SEPSA"},
                     {265, 23, "Puede Recibir y Pagar?"},
                     {266, 11, "Puede Cambiar el Ingreso/Salida de Stock en la Devolución?"},
                     {267, 3, "Puede Abrir la Ventana para Cambiar Montos de Cuotas de Compras?"},
                     {268, 12, "Puede Activar/Desactivar un Producto?"},
                     {269, 8, "Puede ver Reportes de Venta con Detalle de Costos, Utilidad?"},
                     {270, 31, "Puede Abrir la Ventana de Envios de Mercaderia?"},
                     {271, 31, "Puede Crear un Nuevo Envio de Mercaderia?"},
                     {272, 19, "Puede Ajustar el Stock Historico?"},
                     {273, 19, "Puede Generar el Stock Historico?"},
                     {274, 28, "Puede Crear una Orden de Trabajo?"},
                     {275, 28, "Puede Eliminar una Orden de Trabajo?"},
                     {276, 28, "Puede Aprobar una Orden de Trabajo?"},
                     {277, 28, "Puede Anular una Orden de Trabajo?"},
                     {278, 28, "Puede Abrir la Ventana de Orden de Trabajo?"},
                     {279, 28, "Puede Crear una Planilla de Produccion?"},
                     {280, 28, "Puede Eliminar una Planilla de Produccion?"},
                     {281, 28, "Puede Abrir la Ventana de Planilla de Produccion?"},
                     {282, 8, "Puede Generar Pagares?"},
                     {283, 3, "Puede Aplicar Redondeo de IVA?"},
                     {284, 8, "Puede Abrir la Ventana para Cambiar Montos de Cuotas de Ventas?"}}
    End Sub
End Module
