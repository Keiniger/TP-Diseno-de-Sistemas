using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using Quartz;
using TPANUAL.Clases.DAO;
using TPANUAL.Jobs;

namespace TPANUAL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new DB_Context())
            {

                //API_MercadoLibre ml = API_MercadoLibre.getInstance();
                //ml.persistir(contexto);
                //contexto.SaveChanges();

                Usuario u1 = new Usuario("user1", "user1");
                Usuario u2 = new Usuario("user2", "user2");
                Usuario u3 = new Usuario("user3", "user3");
                Usuario u4 = new Usuario("user4", "user4");
                Usuario u5 = new Usuario("user5", "user5");
                Usuario u6 = new Usuario("user6", "user6");
                Usuario u7 = new Usuario("user7", "user7");
                Usuario u8 = new Usuario("user8", "user8");
                Usuario u9 = new Usuario("user9", "user9");
                Usuario u10 = new Usuario("user10", "user10");
                Usuario u11 = new Usuario("user11", "user11");
                Usuario u12 = new Usuario("user12", "user12");
                Usuario u13 = new Usuario("user13", "user13");
                Usuario u14 = new Usuario("user14", "user14");
                Usuario u15 = new Usuario("user15", "user15");
                Usuario u16 = new Usuario("user16", "user16");
                Usuario u17 = new Usuario("user17", "user17");
                Usuario u18 = new Usuario("user18", "user18");
                Usuario u19 = new Usuario("user19", "user19");
                Usuario u20 = new Usuario("user20", "user20");
                Usuario u21 = new Usuario("user20", "user20");
                Usuario u22 = new Usuario("user20", "user20");
                Usuario u23 = new Usuario("user20", "user20");


                List<Usuario> users = new List<Usuario> { u1, u2, u3, u4, u5, u6, u7, u8, u9, u10, u11, u12, u13, u14, u15, u16, u17, u18, u19, u20, u21, u22 , u23 };
                contexto.usuario.AddRange(users);

                Direccion direcEb1 = new Direccion("direccion eb1", "1", 1, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb2 = new Direccion("direccion eb2", "2", 2, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb3 = new Direccion("direccion eb3", "3", 3, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb4 = new Direccion("direccion eb4", "4", 4, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb5 = new Direccion("direccion eb5", "5", 5, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb6 = new Direccion("direccion eb6", "6", 6, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb7 = new Direccion("direccion eb7", "7", 7, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb8 = new Direccion("direccion eb8", "8", 8, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb9 = new Direccion("direccion eb9", "9", 9, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEb10 = new Direccion("direccion eb10", "10", 10, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj1 = new Direccion("direccion ej1", "1", 1, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj2 = new Direccion("direccion ej2", "2", 2, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj3 = new Direccion("direccion ej3", "3", 3, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj4 = new Direccion("direccion ej4", "4", 4, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj5 = new Direccion("direccion ej5", "5", 5, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj6 = new Direccion("direccion ej6", "6", 6, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj7 = new Direccion("direccion ej7", "7", 7, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj8 = new Direccion("direccion ej8", "8", 8, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj9 = new Direccion("direccion ej9", "9", 9, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                Direccion direcEj10 = new Direccion("direccion ej10", "10", 10, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal

                List<Direccion> direcs = new List<Direccion> {direcEb1, direcEb2, direcEb3, direcEb4, direcEb5, direcEb6, direcEb7, direcEb8, direcEb9, direcEb10, direcEj1, direcEj2, direcEj3, direcEj4, direcEj5, direcEj6, direcEj7, direcEj8, direcEj9, direcEj10, };
                contexto.direccion.AddRange(direcs);

                EntidadBase eb1 = new EntidadBase("entidadBase1", null, direcEb1);
                EntidadBase eb2 = new EntidadBase("entidadBase2", null, direcEb2);
                EntidadBase eb3 = new EntidadBase("entidadBase3", null, direcEb3);
                EntidadBase eb4 = new EntidadBase("entidadBase4", null, direcEb4);
                EntidadBase eb5 = new EntidadBase("entidadBase5", null, direcEb5);
                EntidadBase eb6 = new EntidadBase("entidadBase6", null, direcEb6);
                EntidadBase eb7 = new EntidadBase("entidadBase7", null, direcEb7);
                EntidadBase eb8 = new EntidadBase("entidadBase8", null, direcEb8);
                EntidadBase eb9 = new EntidadBase("entidadBase9", null, direcEb9);
                EntidadBase eb10 = new EntidadBase("entidadBase10", null, direcEb10);
                EntidadBase eb11 = new EntidadBase("entidadBase11", null, direcEb10);
                EntidadBase eb12 = new EntidadBase("entidadBase12", null, direcEb10);
                EntidadBase eb13 = new EntidadBase("entidadBase13", null, direcEb10);
                EntidadBase eb14 = new EntidadBase("entidadBase14", null, direcEb10);
                EntidadBase eb15 = new EntidadBase("entidadBase15", null, direcEb10);
                EntidadBase eb16 = new EntidadBase("entidadBase16", null, direcEb10);
                EntidadBase eb17 = new EntidadBase("entidadBase17", null, direcEb10);
                EntidadBase eb18 = new EntidadBase("entidadBase18", null, direcEb10);
                EntidadBase eb19 = new EntidadBase("entidadBase19", null, direcEb10);

                List<EntidadBase> ebs = new List<EntidadBase> { eb1, eb2, eb3, eb4, eb5, eb6, eb7, eb8, eb9, eb10, eb11, eb12, eb13, eb14, eb15, eb16, eb17, eb17, eb18, eb19};
                contexto.entidadbase.AddRange(ebs);

                List<EntidadBase> ebasoc1 = new List<EntidadBase> { eb11 };
                List<EntidadBase> ebasoc2 = new List<EntidadBase> { eb12 };
                List<EntidadBase> ebasoc3 = new List<EntidadBase> { eb13 };
                List<EntidadBase> ebasoc4 = new List<EntidadBase> { eb14 , eb16 };
                List<EntidadBase> ebasoc5 = new List<EntidadBase> { eb15, eb16, eb17, eb18 };

                EntidadJuridica ej1 = new EntidadJuridica(null, "codigo1", "123456789", direcEj1, "entidadJuridica1");
                EntidadJuridica ej2 = new EntidadJuridica(null, "codigo2", "123456789", direcEj2, "entidadJuridica2");
                EntidadJuridica ej3 = new EntidadJuridica(null, "codigo3", "123456789", direcEj3, "entidadJuridica3");
                EntidadJuridica ej4 = new EntidadJuridica(null, "codigo4", "123456789", direcEj4, "entidadJuridica4");
                EntidadJuridica ej5 = new EntidadJuridica(null, "codigo5", "123456789", direcEj5, "entidadJuridica5");
                EntidadJuridica ej6 = new EntidadJuridica(ebasoc1, "codigo6", "123456789", direcEj6, "entidadJuridica6");
                EntidadJuridica ej7 = new EntidadJuridica(ebasoc2, "codigo7", "123456789", direcEj7, "entidadJuridica7");
                EntidadJuridica ej8 = new EntidadJuridica(ebasoc3, "codigo8", "123456789", direcEj8, "entidadJuridica8");
                EntidadJuridica ej9 = new EntidadJuridica(ebasoc4, "codigo9", "123456789", direcEj9, "entidadJuridica9");
                EntidadJuridica ej10 = new EntidadJuridica(ebasoc5, "codigo10", "123456789", direcEj10, "entidadJuridica10");

                List<EntidadJuridica> ejs  = new List<EntidadJuridica> { ej1, ej2, ej3, ej4, ej5, ej6, ej7, ej8, ej9, ej10};
                contexto.entidadjuridica.AddRange(ejs);

                //servicio no es comisionista ni agencia de viaje con entidad base 
                Servicios actividadServicio1 = new Servicios();
                List<Usuario> usuariosDeOrg1 = new List<Usuario> { u1};
                Empresa zapatuya1 = new Empresa(actividadServicio1, 1, false, "zapaTuya", 7900000, eb1, null,usuariosDeOrg1);

                //servicio no es comisionista ni agencia de viaje con entidad juridica  
                Servicios actividadServicio2 = new Servicios();
                List<Usuario> usuariosDeOrg2 = new List<Usuario> { u2};
                OSC zapatuya2 = new OSC(actividadServicio2, 1, "zapaTuya2", 7900000, eb2, null, usuariosDeOrg2);
      

                //servicio es comisionista / agencia de viaje con entidad base  
                Servicios actividadServicio3 = new Servicios();
                List<Usuario> usuariosDeOrg3 = new List<Usuario> {u3 };
                Empresa zapatuya3 = new Empresa(actividadServicio3, 1, false, "zapaTuya3", 7900000, eb3, null, usuariosDeOrg3);

                //servicio es comisionista / agencia de viaje con entidad base  
                Servicios actividadServicio4 = new Servicios();
                List<Usuario> usuariosDeOrg4 = new List<Usuario> { u4 };
                OSC zapatuya4 = new OSC(actividadServicio4, 1, "zapaTuya4", 7900000, null, ej1, usuariosDeOrg4);

                // es actividad comisionista o agencia de viaje 
                Agropecuario actividadAgropecuario1 = new Agropecuario();
                List<Usuario> usuariosAgropecuario1 = new List<Usuario> {u5};
                Empresa superSoja1 = new Empresa(actividadAgropecuario1, 5, true, "superSoja1", 71970000, null ,ej2, usuariosAgropecuario1);

                Agropecuario actividadAgropecuario2 = new Agropecuario();
                List<Usuario> usuariosAgropecuario2 = new List<Usuario> { u6 };
                OSC superSoja2 = new OSC(actividadAgropecuario2, 5, "superSoja2", 71970000, eb4, null, usuariosAgropecuario2); 

                Agropecuario actividadAgropecuario3 = new Agropecuario();
                List<Usuario> usuariosAgropecuario3 = new List<Usuario> { u7 };
                Empresa superSoja3 = new Empresa(actividadAgropecuario3, 5, false, "superSoja3", 71970000, null, ej3, usuariosAgropecuario3);

                Agropecuario actividadAgropecuario4 = new Agropecuario();
                List<Usuario> usuariosAgropecuario4 = new List<Usuario> { u8 };
                OSC superSoja4 = new OSC(actividadAgropecuario4, 5, "superSoja4", 71970000, null, ej4, usuariosAgropecuario4);


                Comercio actividadComercio1 = new Comercio();
                List<Usuario> usuariosDeComercio1 = new List<Usuario> { u9 };
                Empresa tiendaCTM1 = new Empresa(actividadComercio1, 40, false, "tiendaCTM1", 207200000, null, ej5, usuariosDeComercio1);

                Comercio actividadComercio2 = new Comercio();
                List<Usuario> usuariosDeComercio2 = new List<Usuario> { u10 };
                OSC tiendaCTM2 = new OSC(actividadComercio2, 40, "tiendaCTM2", 207200000, eb5, null, usuariosDeComercio2);

                Comercio actividadComercio3 = new Comercio();
                List<Usuario> usuariosDeComercio3 = new List<Usuario> { u11, u21, u22, u23 };
                Empresa tiendaCTM3 = new Empresa(actividadComercio3, 40, false, "tiendaCTM3", 207200000, null, ej6, usuariosDeComercio3);

                Comercio actividadComercio4 = new Comercio();
                List<Usuario> usuariosDeComercio4 = new List<Usuario> { u12 };
                OSC tiendaCTM4 = new OSC(actividadComercio4, 40, "tiendaCTM4", 207200000, eb6, null, usuariosDeComercio4);

                IndustriaYMineria actividadIYM1 = new IndustriaYMineria();
                List<Usuario> usuariosDeMineria1 = new List<Usuario> { u13 };
                Empresa MinMining1 = new Empresa(actividadIYM1, 50, false, "MinMining1", 1651750001, null, ej7, usuariosDeMineria1);

                IndustriaYMineria actividadIYM2 = new IndustriaYMineria();
                List<Usuario> usuariosDeMineria2 = new List<Usuario> { u14 };
                OSC MinMining2 = new OSC(actividadIYM2, 50, "MinMining2", 1651750001, null, ej8, usuariosDeMineria2);

                IndustriaYMineria actividadIYM3 = new IndustriaYMineria();
                List<Usuario> usuariosDeMineria3 = new List<Usuario> { u15 };
                Empresa MinMining3 = new Empresa(actividadIYM3, 50, false, "MinMining3", 1651750001, eb7, null, usuariosDeMineria3);

                IndustriaYMineria actividadIYM4 = new IndustriaYMineria();
                List<Usuario> usuariosDeMineria4 = new List<Usuario> { u16 };
                OSC MinMining4 = new OSC(actividadIYM4, 50, "MinMining4", 1651750001, eb8, null, usuariosDeMineria4);


                Construccion actividadConstruccion1 = new Construccion();
                List<Usuario> usuariosDeConstruccion1 = new List<Usuario> {u17 };
                Empresa DunMaker1 = new Empresa(actividadConstruccion1, 600, false, "DunMaker1", 690710000, eb9, null, usuariosDeConstruccion1);

                Construccion actividadConstruccion2 = new Construccion();
                List<Usuario> usuariosDeConstruccion2 = new List<Usuario> { u18 };
                OSC DunMaker2 = new OSC(actividadConstruccion2, 600, "DunMaker2", 690710000, eb10, null, usuariosDeConstruccion2);

                Construccion actividadConstruccion3 = new Construccion();
                List<Usuario> usuariosDeConstruccion3 = new List<Usuario> { u19 };
                Empresa DunMaker3 = new Empresa(actividadConstruccion3, 600, true, "DunMaker3", 690710000, null, ej9, usuariosDeConstruccion3);

                Construccion actividadConstruccion4 = new Construccion();
                List<Usuario> usuariosDeConstruccion4 = new List<Usuario> { u20 };
                OSC DunMaker4 = new OSC(actividadConstruccion4, 600, "DunMaker4", 690710000,null, ej10, usuariosDeConstruccion4);


                //guardo organizacion
                List<Empresa> empresas = new List<Empresa> { zapatuya1, zapatuya3, superSoja1, superSoja3, tiendaCTM1, tiendaCTM3, MinMining1, MinMining3, DunMaker1, DunMaker3 };
                contexto.empresas.AddRange(empresas);
                List<OSC> oscs = new List<OSC> { zapatuya2, zapatuya4, superSoja2, superSoja4, tiendaCTM2, tiendaCTM4, MinMining2, MinMining4, DunMaker2, DunMaker4 };
                contexto.oscs.AddRange(oscs);

                var oi = crear<OperacionDeIngreso>(100);
                var oe = crear<OperacionDeEgreso>(100);

                foreach (Empresa e in empresas)
                {
                    e.OperacionesDeIngreso.AddRange(oi.Take(3));
                    e.OperacionesDeEgreso.AddRange(oe.Take(3));
                    oi.RemoveRange(0, 3);
                    oe.RemoveRange(0, 3);
                }
                foreach (OSC e in oscs)
                {
                    e.OperacionesDeIngreso.AddRange(oi.Take(3));
                    e.OperacionesDeEgreso.AddRange(oe.Take(3));
                    oi.RemoveRange(0, 3);
                    oe.RemoveRange(0, 3);
                }

                contexto.SaveChanges();
        
                /*
        * Crea x cantidad de objetos con valores aleatorios. Ejemplo:
        * List<Usuario> usuarios = crear<Usuario>(20); // Crea una lista de 20 usuarios
        * 
        * Si se necesita solo 1 objeto aleatorio, se puede hacer así:
        * Usuario u = crear<Usuario>(1)[0];
        */
                static List<T> crear<T>(int cantidad)
                {
                    var lista = new List<dynamic> { };

                    using (var contexto = new DB_Context())
                    {
                        for (int i = 0; i < cantidad; i++)
                        {
                            Random random = new Random();
                            var actividades = new List<Actividad> { new Servicios(), new Agropecuario(), new Comercio(), new IndustriaYMineria(), new Construccion() };

                            //if (typeof(Usuario) == typeof(T))
                            //    lista.Add(new Usuario("Usuario-" + i.ToString(), "Contraseña-" + i.ToString()));

                            if (typeof(Mensaje) == typeof(T))
                                lista.Add(new Mensaje("Texto-" + i.ToString()));

                            if (typeof(Criterio) == typeof(T))
                                lista.Add(new Criterio("NombreCriterio-" + i.ToString(), null));

                            if (typeof(Categoria) == typeof(T))
                                lista.Add(new Categoria("NombreCategoria-" + i.ToString(), new Criterio("NombreCriterio-" + i.ToString(), null)));

                            if (typeof(Item) == typeof(T))
                                lista.Add(new Item("Nombre-" + i.ToString(), "Descripcion-" + i.ToString(), random.Next(50, 6000), crear<Categoria>(random.Next(1, 3))));

                            if (typeof(MedioDePago) == typeof(T))
                                lista.Add(new MedioDePago("AR", random.Next(0, 10).ToString(), "TipoDePago-" + i.ToString()));

                            if (typeof(DocumentoComercial) == typeof(T))
                                lista.Add(new DocumentoComercial(random.Next(0, 10), "TipoDocumento-" + i.ToString()));

                            if (typeof(PersonaProveedora) == typeof(T))
                                lista.Add(new PersonaProveedora(crear<Direccion>(1)[0], random.Next(00000000, 99999999).ToString(), "Nombre-" + i.ToString()));

                            if (typeof(EntidadJuridicaProveedora) == typeof(T))
                                lista.Add(new EntidadJuridicaProveedora(crear<Direccion>(1)[0], "CodigoInscripcion-" + i.ToString(), "CUIT-" + i.ToString(), "RazonSocial-" + i.ToString()));

                            if (typeof(OperacionDeEgreso) == typeof(T))
                                lista.Add(new OperacionDeEgreso(crear<Compra>(1)[0], crear<MedioDePago>(1)[0], crear<DocumentoComercial>(random.Next(1, 5)), DateTime.Now));

                            if (typeof(OperacionDeIngreso) == typeof(T))
                                lista.Add(new OperacionDeIngreso("Descripcion-" + i.ToString(), null, random.Next(10, 100000), DateTime.Now));

                            if (typeof(Presupuesto) == typeof(T))
                                lista.Add(new Presupuesto(null, null, crear<Item>(random.Next(0, 5)), null, "Detalle-" + i.ToString(), crear<DocumentoComercial>(random.Next(0, 5))));

                            if (typeof(Direccion) == typeof(T))
                                lista.Add(new Direccion("Calle-" + i.ToString(), i.ToString(), i, null));

                            if (typeof(Compra) == typeof(T))
                            {
                                PersonaProveedora pp = null;
                                EntidadJuridicaProveedora ejp = null;
                                int presReq = random.Next(0, 5);
                                var presupuestos = crear<Presupuesto>(presReq);
                                var mensajes = crear<Mensaje>(random.Next(0, 5));

                                // Para crear la compra con proveedor
                                if (random.Next(0, 2) == 0)
                                    pp = crear<PersonaProveedora>(1)[0];
                                else
                                    ejp = crear<EntidadJuridicaProveedora>(1)[0];

                                var c = new Compra(presReq, new MenorValor(), crear<Item>(random.Next(0, 5)), null, pp, ejp);

                                for (int j = 0; j < presReq; j++)
                                    c.agregarPresupuesto(presupuestos[j]);

                                for (int k = 0; k < mensajes.Count; k++)
                                    c.agregarMensaje(mensajes[k].texto);

                                lista.Add(c);
                            }

                            //Está comentado porque crea todas las orgs con el mismo nombre
                            if (typeof(Organizacion) == typeof(T))
                                if (random.Next(0, 2) == 0)
                                    lista.Add(crear<Empresa>(1)[0]);
                                else
                                    lista.Add(crear<OSC>(1)[0]);

                            if (typeof(Empresa) == typeof(T))
                            {
                                EntidadBase eb = null;
                                EntidadJuridica ej = null;

                                if (random.Next(0, 2) == 0)
                                    eb = crear<EntidadBase>(1)[0];
                                else
                                    ej = crear<EntidadJuridica>(1)[0];

                                lista.Add(
                                    new Empresa(
                                        actividades[random.Next(0, 5)],
                                        random.Next(0, 50),
                                        random.Next(0, 1) == 0,
                                        "NombreEmpresa-" + i.ToString(),
                                        random.Next(1000, 100000),
                                        eb,
                                        ej,
                                        crear<Usuario>(random.Next(0, 10)))
                                    );
                            }

                            if (typeof(OSC) == typeof(T))
                            {
                                EntidadBase eb = null;
                                EntidadJuridica ej = null;

                                if (random.Next(0, 2) == 0)
                                    eb = crear<EntidadBase>(1)[0];
                                else
                                    ej = crear<EntidadJuridica>(1)[0];

                                lista.Add(new OSC(
                                        actividades[random.Next(0, 4)],
                                        random.Next(0, 50),
                                        "NombreOSC-" + i.ToString(),
                                        random.Next(1000, 100000),
                                        eb,
                                        ej,
                                        crear<Usuario>(random.Next(0, 10)))
                                    );
                            }

                            if (typeof(TipoEntidad) == typeof(T))
                            {
                                if (random.Next(0, 2) == 0)
                                    lista.Add(crear<EntidadBase>(1));
                                else
                                    lista.Add(crear<EntidadJuridica>(1));
                            }

                            if (typeof(EntidadBase) == typeof(T))
                            {
                                EntidadJuridica ej = crear<EntidadJuridica>(1)[0];
                                ej.BasesAsociadas = new List<EntidadBase> { }; // Vacio las entidades base aleaotrias creadas
                                EntidadBase eb = new EntidadBase("Descripción-" + i.ToString(), ej, crear<Direccion>(1)[0]);
                                ej.BasesAsociadas.Add(eb);

                                lista.Add(eb);
                            }

                            if (typeof(EntidadJuridica) == typeof(T))
                            {
                                var eb = new List<EntidadBase> { };

                                if (random.Next(0, 10) > 7)
                                    eb = crear<EntidadBase>(random.Next(0, 3));

                                lista.Add(new EntidadJuridica(eb, "CodigoInscripción-" + i.ToString(), "CUIT-" + i.ToString(), crear<Direccion>(1)[0], "RazonSocial-" + i.ToString()));
                            }
                        }
                    }

                    return lista.Cast<T>().ToList();
                }
                /*
                //creo Criterios
                Criterio barrios = new Criterio("barrio", null);
                Criterio clientes = new Criterio("cliente", barrios);
                Criterio ropa = new Criterio("ropa", null);
                Criterio calzado = new Criterio("Calzado", ropa);
                Criterio magia = new Criterio("magia", null);
                Criterio pociones = new Criterio("pociones", magia);
                Criterio comida = new Criterio("Comida", null);
                Criterio comidaCaliente = new Criterio("Comida Caliente", comida);
                Criterio comidaCalienteParaLlevar = new Criterio("Comida Caliente Para Llevar", comidaCaliente);
                Criterio Alguno = new Criterio("Alguno", null);

                List<Criterio> listcrit = new List<Criterio> { barrios, clientes, ropa, calzado, magia, pociones, comida, comidaCaliente, comidaCalienteParaLlevar };
                contexto.criterio.AddRange(listcrit);

                //creo Categorias
                Categoria almagro = new Categoria("almagro", barrios);
                Categoria clienteA = new Categoria("clienteA", clientes);
                Categoria calzadoTipoA = new Categoria("Calzado Tipo A", calzado);
                Categoria calzadoTipoB = new Categoria("Calzado Tipo B", calzado);
                Categoria calzadoModerno = new Categoria("Calzado Moderno", calzado);
                Categoria magiaNegra = new Categoria("Magia Negra", magia);
                Categoria pocionesYHechizos = new Categoria("posiones y hechizos", pociones);
                Categoria guiso = new Categoria("Guisos", comidaCalienteParaLlevar);
                Categoria fideos = new Categoria("Fideos", comidaCaliente);
                Categoria alguna = new Categoria("Alguna", Alguno);

                List<Categoria> listcat = new List<Categoria> { almagro, clienteA, calzadoTipoA, calzadoTipoB, calzadoModerno, magiaNegra, pocionesYHechizos, guiso, fideos, alguna };
                contexto.categoria.AddRange(listcat);

                //creo proveedor Mirna
                PersonaProveedora mirna = new PersonaProveedora(direcMirna, "23098213", "Mirna");

                List<Categoria> categoriasMirnaTrabajo = new List<Categoria> { calzadoTipoA, calzadoTipoB };
                List<Categoria> categoriasMirnaModerno = new List<Categoria> { calzadoModerno };
                //Item BotaDeTrabajo1 = new Item("melman", "Bota de trabajo", 300, categoriasMirnaTrabajo);
                //Item BotaDeTrabajo2 = new Item("gloria", "Bota de trabajo Super", 400, categoriasMirnaTrabajo);
                //Item AirmaxSuperPro = new Item("airmaxSuperPro", "la super tilla ", 500, categoriasMirnaModerno);
                //Item AirmaxBatmanEdition = new Item("airmaxBatmanEdition", "super tilla version batman", 600, categoriasMirnaModerno);

                //BotaDeTrabajo1.insertarCategoria(calzadoTipoA);
                //BotaDeTrabajo2.insertarCategoria(calzadoTipoB);
                //AirmaxSuperPro.insertarCategoria(calzadoModerno);
                //AirmaxBatmanEdition.insertarCategoria(calzadoModerno);



                //creo proveedor Isma
                PersonaProveedora isma = new PersonaProveedora(direcIsma, "21439203", "Isma");

                List<Categoria> categoriaIsma = new List<Categoria> { pocionesYHechizos, magiaNegra };
                //Item pataDeConejo = new Item("PataBlanca", "patas de conejo", 12332, categoriaIsma);
                //Item venenoMagico = new Item("shotDeTequila", "veneno para matar ", 1200, categoriaIsma);
                //Item posimaDelInfierno = new Item("aguaMagica", "pocion magica", 666, categoriaIsma);

                //pataDeConejo.insertarCategoria(magiaNegra);
                //venenoMagico.insertarCategoria(pocionesYHechizos);
                //posimaDelInfierno.insertarCategoria(pocionesYHechizos);

                //creo proveedor Isma
                PersonaProveedora kronk = new PersonaProveedora(direcKronk, "34245231", "Kronk");

                List<Categoria> categoriakronk = new List<Categoria> { guiso, fideos };
                //Item fideosDeEspinaja = new Item("Espinaja", "Fideos De Espinaca", 100, categoriakronk);
                //Item guisoDeMondongo = new Item("Mondongo", "Guiso De Mondongo ", 200, categoriakronk);


                //fideosDeEspinaja.insertarCategoria(fideos);
                //guisoDeMondongo.insertarCategoria(guiso);

                PersonaProveedora cuzco = new PersonaProveedora(direcCuzco, "10239726", "Cuzco");
                List<Categoria> categoriaCuzco = new List<Categoria> { alguna };
                //Item alguno = new Item("alguno", "ya me aburri", 123123, categoriaCuzco);

                //guardo el proveedor
                contexto.personaProveedora.Add(mirna);
                contexto.personaProveedora.Add(isma);
                contexto.personaProveedora.Add(kronk);
                contexto.personaProveedora.Add(cuzco);



                /*OPERACION DE EGRESO 1*/   /*

                //creo atributos de compra 1
                List<Usuario> usuariosRevisoresCompra1 = new List<Usuario> { pedro, scarlet, daniel };
                Item item1Compra1 = new Item("zapatillas", "rositas", 126312, categoriasMirnaModerno);
                Item item2Compra1 = new Item("zapatillas", "azules", 126312, categoriasMirnaModerno);
                Item item3Compra1 = new Item("zapatillas", "verdes", 126312, categoriasMirnaModerno);
                Item item4Compra1 = new Item("zapatillas", "marrones", 126312, categoriasMirnaModerno);
                List<Item> itemsCompra1 = new List<Item> { item1Compra1, item2Compra1, item3Compra1, item4Compra1 };

                //creo atributos de compra 2
                List<Usuario> usuariosRevisoresCompra2 = new List<Usuario> { megan, juan, dillon };
                Item item1Compra2 = new Item("pataDeConejo", "Patas De Conejo", 20320, categoriaIsma);
                List<Item> itemsCompra2 = new List<Item> { item1Compra2, item1Compra2, item1Compra2, item1Compra2 };

                //creo atributos de compra 3
                List<Usuario> usuariosRevisoresCompra3 = new List<Usuario> { matias, nacho, giu, fran };
                Item item1Compra3 = new Item("guiso 1", "guiso de mariscos", 100, categoriakronk);
                Item item2Compra3 = new Item("guiso 2", "guiso de lentejas", 200, categoriakronk);
                Item item3Compra3 = new Item("fideos 1", "fuciles con salsa rosa", 300, categoriakronk);
                Item item4Compra3 = new Item("fideos 2", "spaguettis con bolognesa", 300, categoriakronk);
                List<Item> itemsCompra3 = new List<Item> { item1Compra3, item1Compra3, item1Compra3, item2Compra3, item3Compra3, item3Compra3, item3Compra3, item4Compra3 };

                contexto.item.AddRange(itemsCompra1.Concat(itemsCompra2.Concat(itemsCompra3)));

                //creo criterioDeSeleccion
                MenorValor criterio = new MenorValor();

                //creo Compras
                Compra compra1 = new Compra(1, criterio, itemsCompra1, usuariosRevisoresCompra1, mirna, null);
                Compra compra2 = new Compra(2, criterio, itemsCompra2, usuariosRevisoresCompra2, isma, null);
                Compra compra3 = new Compra(3, criterio, itemsCompra3, usuariosRevisoresCompra3, kronk, null);

                List<Compra> listcom = new List<Compra> { compra1, compra2, compra3 };
                contexto.compra.AddRange(listcom);

                //creo MediosDePago
                MedioDePago medio1 = new MedioDePago("AR", "1", "cash");
                MedioDePago medio2 = new MedioDePago("AR", "2", "debito");
                MedioDePago medio3 = new MedioDePago("AR", "3", "credito");

                List<MedioDePago> listmed = new List<MedioDePago> { medio1, medio2, medio3 };
                contexto.mediodepago.AddRange(listmed);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso1 = new OperacionDeEgreso(compra1, medio1, null, DateTime.Now);
                OperacionDeEgreso operacionDeEgreso2 = new OperacionDeEgreso(compra2, medio2, null, DateTime.Now);
                OperacionDeEgreso operacionDeEgreso3 = new OperacionDeEgreso(compra3, medio3, null, DateTime.Now);

                operacionDeEgreso1.valorTotal();
                operacionDeEgreso2.valorTotal();
                operacionDeEgreso3.valorTotal();

                List<OperacionDeEgreso> listoe = new List<OperacionDeEgreso> { operacionDeEgreso1, operacionDeEgreso2, operacionDeEgreso3 };
                contexto.operacionDeEgreso.AddRange(listoe);

                //agrego a empresa todas las operaciones de egresos
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso1);
                superSoja.agregarOperacionDeEgreso(operacionDeEgreso2);
                MinMining.agregarOperacionDeEgreso(operacionDeEgreso3);


                /*CREO Y AGREGO OPERACIONES DE INGRESO*/   /* 

                OperacionDeIngreso op1 = new OperacionDeIngreso("Prestamo", null, 7824, DateTime.Now);
                OperacionDeIngreso op2 = new OperacionDeIngreso("Prestamo", null, 23734, DateTime.Now);
                OperacionDeIngreso op3 = new OperacionDeIngreso("Prestamo", null, 127623, DateTime.Now);
                OperacionDeIngreso op4 = new OperacionDeIngreso("Prestamo", null, 1273, DateTime.Now);
                OperacionDeIngreso op5 = new OperacionDeIngreso("Prestamo", null, 12673, DateTime.Now);
                OperacionDeIngreso op6 = new OperacionDeIngreso("Prestamo", null, 27, DateTime.Now);
                OperacionDeIngreso op7 = new OperacionDeIngreso("Prestamo", null, 1632, DateTime.Now);
                OperacionDeIngreso op8 = new OperacionDeIngreso("Prestamo", null, 1554, DateTime.Now);
                OperacionDeIngreso op9 = new OperacionDeIngreso("Prestamo", null, 16327, DateTime.Now);
                OperacionDeIngreso op10 = new OperacionDeIngreso("Prestamo", null, 1563, DateTime.Now);

                List<OperacionDeIngreso> opingr = new List<OperacionDeIngreso> { op1, op2, op3, op4, op5, op6, op7, op8, op9, op10};
                contexto.operacionDeIngreso.AddRange(opingr);

                foreach (OperacionDeIngreso operacion in opingr)
                {
                    zapatuya.agregarOperacionDeIngreso(operacion);
                }

                contexto.SaveChanges();

                EntidadJuridicaProveedora ejp = new EntidadJuridicaProveedora(contexto.direccion.Find(12), "ejp", "1212837192837", "ejpRazonSocial");

                contexto.entidadJuridicaProveedora.Add(ejp);

                contexto.SaveChanges();

                var persona = EntidadJuridicaProveedoraDAO.obtenerEntidadJuridicaProveedora(1);

                Console.WriteLine(persona.RazonSocial);
                Console.WriteLine(persona.CUIT);
                Console.WriteLine(persona.CodigoInscripcion);
                Console.WriteLine(persona.ID_Proveedor);
                Console.WriteLine(persona.ID_Direccion);

                var per = PersonaProveedoraDAO.obtenerPersonaProveedora(1);

                Console.WriteLine(per.ID_Proveedor);
                Console.WriteLine(per.ID_Direccion);
                Console.WriteLine(per.DNI);
                Console.WriteLine(per.Nombre);

                Console.ReadLine();

                
                /*
                //creo Scheduler

                Scheduler sched = Scheduler.getInstance();
                sched.run();
                jobComplejo(sched, zapatuya);

                jose.verMensajes(compra);

                ValidadorDeContraseña.getInstanceValidadorContra.validarContraseña(jose.Constraseña);
                ValidadorDeContraseña.getInstanceValidadorContra.mostrarMsjValidador(jose.Constraseña);

                compra.agregarPresupuesto(presJuan);

                Console.ReadLine();

                jose.verMensajes(compra);

                sched.stop();
                */

            }
        }

        private static void jobComplejo(Scheduler sched, Organizacion organizacion)
        {

            // Guardo el objeto dentro un objeto diccionario para que pueda accederlo desde el job
            JobDataMap jobData = new JobDataMap();

            jobData.Add("organizacion", organizacion);

            IJobDetail jobComp = JobBuilder.Create<JobCompra>()
                .WithIdentity("trabajoCompra", "grupoCompras")
                // Aca le asigno meto el diccionario dentro del job
                .UsingJobData(jobData)
                .Build();

            ITrigger triggerComp = TriggerBuilder.Create()
                  .WithIdentity("triggerCompra", "grupoCompras")
                  .StartNow()
                  // Este trigger se va a ejecutar cada 5 segundos
                  .WithSimpleSchedule(x => x.RepeatForever()
                      .WithIntervalInSeconds(5)
                      .RepeatForever())
                  .Build();

            // Asocio el job con el trigger
            sched.agregarTask(jobComp, triggerComp);

            // Pauso el hilo por 3 segundos 

            System.Threading.Thread.Sleep(6000);

        }
    }


}
// La organizacion "ZapaTuya" tiene a Pedro y Jose de empleados(usuarios) 
// Juan, el proveedor que tiene 5 zapatillas le vende a ZapaTuya 3 a 10$ cada una. 
// ZapaTuya tambien consigue presupuestos de Roberto.
// Roberto las vende a 7$ cada par
// Pedro tambien compra cordones a 2$, pero sin presupuesto.
// Pedro y Jose son revisores de la compra de 5 zapatillas.
// Pedro ve los mensajes de errores de la compra.
