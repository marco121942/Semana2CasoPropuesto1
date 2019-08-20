# Semana2CasoPropuesto1
Create procedure caso1
@nombreApellido VARCHAR(40)
as
select IdPedido,IdCliente,FechaPedido,FechaEntrega,Empleados.Nombre,Empleados.Apellidos
from Pedidos
inner join Empleados on Empleados.IdEmpleado = Pedidos.IdEmpleado
where Empleados.Nombre + Empleados.Apellidos like '%'+@nombreApellido+'%'
