using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;


namespace Enneto
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Producto
        private ObservableCollection<Producto> Productos;
        public ObservableCollection<Producto> producto
        {
            get { return Productos; }
            set {
                Productos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("producto"));
            }
        }

        //Categoria
        private ObservableCollection<Categorias> Categorias;
        public ObservableCollection<Categorias> categoria
        {
            get { return Categorias; }
            set
            {
                Categorias = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("categoria"));
            }
        }

        public MainViewModel()
        {
            producto = new ObservableCollection<Producto>();
            categoria = new ObservableCollection<Categorias>();
            addData();
        }

        private void addData()
        {
            //Lista de Productos
            //Sets
            producto.Add(new Producto
            {
                id = 0,
                idCategoria = 4,
                NombreProducto = "Set Cocina",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sets.png",
                Precio = 490.99,
                Oferta = 300.00f,
                Calificacion = 5.0f,
                Imagen = "mubles1.jpg",
                Estado = "Nuevo"

            });

            producto.Add(new Producto
            {
                id = 1,
                idCategoria = 4,
                NombreProducto = "Set de Sala",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet ",
                categoria = "sets.png",
                Precio = 400.99,
                Oferta = 300f,
                Calificacion = 5.0f,
                Imagen = "muebles4.jpg",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 2,
                idCategoria = 4,
                NombreProducto = "Juego de Comedor Deli 8 Personas",
                Descripcion = "Ancho 201 cm, Largo 101 cm, Alto 74 cm, 8 piezas",
                categoria = "sets.png",
                Precio = 6499.99,
                Oferta = 6199.90f,
                Calificacion = 5.0f,
                Imagen = "JuegodeComedorDeli8Personas.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 3,
                idCategoria = 4,
                NombreProducto = "Juego de comedor Tavarúa 6 personas",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sets.png",
                Precio = 902.99,
                Oferta = 700.12f,
                Calificacion = 5.0f,
                Imagen = "JuegodecomedorTavarua6personas.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 4,
                idCategoria = 4,
                NombreProducto = "Juego de comedor Tavarua 8 personas",
                Descripcion = "Alto 75 cm, Ancho 95 cm, Largo 180 cm",
                categoria = "sets.png",
                Precio = 1299.99,
                Oferta = 1100.00f,
                Calificacion = 5.0f,
                Imagen = "JuegodecomedorTavarua8personas.png",
                Estado = "Nuevo"
            });

            //Closets
            producto.Add(new Producto
            {
                id = 5,
                idCategoria = 2,
                NombreProducto = "Ropero",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "closet.png",
                Precio = 150.99,
                Oferta = 70f,
                Calificacion = 5.0f,
                Imagen = "ropero3.png",
                Estado = "Usado"
            });

            producto.Add(new Producto
            {
                id = 6,
                idCategoria = 2,
                NombreProducto = "Ropero Blanco",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "closet.png",
                Precio = 120.99,
                Oferta = 70f,
                Calificacion = 5.0f,
                Imagen = "ropero2.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 7,
                idCategoria = 2,
                NombreProducto = "Ropero 7 puertas 2 cajones Barcelona",
                Descripcion = "Material jaladores: Plástico, Material correderas: Metal, Material bisagras: Metal, Material fondo: MDF, Material barra: Metal",
                categoria = "closet.png",
                Precio = 679.99,
                Oferta = 600.00f,
                Calificacion = 2.0f,
                Imagen = "Ropero7puertas2cajonesBarcelona.png",
                Estado = "Nuevo"
            });


            producto.Add(new Producto
            {
                id = 8,
                idCategoria = 2,
                NombreProducto = "Ropero 7 puertas 2 cajones con espejo Berna",
                Descripcion = "Con este ropero podrás tener toda tu ropa organizada gracias a los diferentes compartimientos que posee. Tiene 7 puertas en ellas podrás colgar, vestidos, camisas, pantalones o lo que prefieras o podrás apilar la ropa que desees gracias a sus diferentes divisiones. También posee 2 cajones para ropa un poco más pequeña. Está elaborado en Aglomerado de madera con manillas de plástico y un acabado melamine brillante en color marrón. Posee correderas metálicas y cajones elaborados en MDF un material similar a la madera.",
                categoria = "closet.png",
                Precio = 549.99,
                Oferta = 500.00f,
                Calificacion = 4.0f,
                Imagen = "Ropero7puertas2cajonesconespejoBerna.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 9,
                idCategoria = 2,
                NombreProducto = "Ropero 6 puertas 2 cajones Laos",
                Descripcion = "Material jaladores: Plástico, Material correderas: Metal, Material bisagras: Metal, Material fondo: MDF, Material barra: Metal",
                categoria = "closet.png",
                Precio = 399.99,
                Oferta = 349.90f,
                Calificacion = 4.3f,
                Imagen = "Ropero6puertas2cajonesLao.png",
                Estado = "Nuevo"
            });

            //Sillones
            producto.Add(new Producto
            {
                id = 10,
                idCategoria = 5,
                NombreProducto = "Sofa Hogar",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sillon.png",
                Precio = 490.99,
                Oferta = 210f,
                Calificacion = 2.0f,
                Imagen = "muebles2.jpg",
                Estado = "Maltratado"
            });

            producto.Add(new Producto
            {
                id = 11,
                idCategoria = 5,
                NombreProducto = "Set de Sillones",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sillon.png",
                Precio = 400.00,
                Oferta = 300f,
                Calificacion = 4.0f,
                Imagen = "muebles3.jpg",
                Estado = "Restaurado"
            });

            producto.Add(new Producto
            {
                id = 12,
                idCategoria = 5,
                NombreProducto = "Sofá Catania 3 Cuerpos Azul",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sillon.png",
                Precio = 1349.99,
                Oferta = 1249.00f,
                Calificacion = 3.0f,
                Imagen = "SofaCatania3CuerposAzul.jpg",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 13,
                idCategoria = 5,
                NombreProducto = "Poltrona Mostaza",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sillon.png",
                Precio = 799.99,
                Oferta = 600.00f,
                Calificacion = 2.0f,
                Imagen = "PoltronaMostaza.jpg",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 14,
                idCategoria = 5,
                NombreProducto = "Sitial Verdi Beige",
                Descripcion = "Lorem ipsum dolor sit amet consectetur adipiscing elit vivamus curabitur magnis ad id vitae ridiculus, malesuada erat ut commodo fringilla velit est tincidunt nascetur quisque litora fermentum. Ad id facilisis aliquet imperdiet lacus vivamus dignissim purus, ante risus montes parturient leo nis",
                categoria = "sillon.png",
                Precio = 279.99,
                Oferta = 200.00f,
                Calificacion = 2.0f,
                Imagen = "SitialVerdiBeige.jpg",
                Estado = "Nuevo"
            });


            //Estantes
            producto.Add(new Producto
            {
                id = 15,
                idCategoria = 3,
                NombreProducto = "Estante Ness 3 Puertas Natural Blanco",
                Descripcion = "Módulo vertical de estilo nórdico adaptable a diferentes estancias. Compuesto por 3 puertas y 4 estantes nos ofrece mucho espacio de almacenaje.",
                categoria = "estante.png",
                Precio = 579.99,
                Oferta = 529.30f,
                Calificacion = 4.0f,
                Imagen = "EstanteNess3PuertasNaturalBlanco.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 16,
                idCategoria = 3,
                NombreProducto = "Estante Hermes Negro Mate",
                Descripcion = "Renueva tu hogar con Estante Hermes Negro Mate.",
                categoria = "estante.png",
                Precio = 349.99,
                Oferta = 329.00f,
                Calificacion = 5.0f,
                Imagen = "EstanteHermesNegroMate.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 17,
                idCategoria = 3,
                NombreProducto = "Estante Pontal 4 Niveles 2 Cajones",
                Descripcion = "Cantidad de Cajones: 2,Color: Marrón Rústico",
                categoria = "estante.png",
                Precio = 399.99,
                Oferta = 369.00f,
                Calificacion = 5.0f,
                Imagen = "EstantePontal4Niveles2Cajones.png",
                Estado = "Nuevo"
            });

            //Otros
            producto.Add(new Producto
            {
                id = 18,
                idCategoria = 1,
                NombreProducto = "Puff Lotus 2 cuerpos tela",
                Descripcion = "No dejes de disfrutar y ahorrar espacio en tu casa con este elgante puff y que tu hogar refleje todo tu estilo.",
                categoria = "bolsa.png",
                Precio = 69.99,
                Oferta = 62.91f,
                Calificacion = 4.0f,
                Imagen = "muebles3.jpg",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 19,
                idCategoria = 1,
                NombreProducto = "Silla de terraza colgante Yoyo con estructura",
                Descripcion = "Disfruta y contempla de una manera diferente la naturaleza en tu jardín o terraza, relájate de una manera única con esta silla de terraza colgante que te hará sentir muy cómoda.",
                categoria = "bolsa.png",
                Precio = 999.99,
                Oferta = 800.80f,
                Calificacion = 5.0f,
                Imagen = "SilladeterrazacolganteYoyoconstructura.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 20,
                idCategoria = 1,
                NombreProducto = "Escritorio Praga Rustic",
                Descripcion = "Escritorio Praga color rustic. Su textura, amplio espacio y diseño nórdico, hacen de este el escritorio ideal. La profundidad de 60 cm. Y ancho de 120 cm. Permiten trabajar cómodamente. El espesor del tablero es de 25 mm. Su estructura es de aglomerado de madera MDP y su acabado cuenta con 7 capas de pintura poliéster, lo que la hace resistente a los rayos UV, la abrasión y la humedad.",
                categoria = "bolsa.png",
                Precio = 549.99,
                Oferta = 449.90f,
                Calificacion = 4.0f,
                Imagen = "EscritorioPragaRustic.png",
                Estado = "Nuevo"
            });

            producto.Add(new Producto
            {
                id = 21,
                idCategoria = 1,
                NombreProducto = "Silla Gamer Master",
                Descripcion = "la silla gamer que maneja un máximo nivel de comodidad y diversión. Ideal para pasar horas en la computadora bien sea jugando o de trabajo. ¡No esperes más y compra ya!",
                categoria = "bolsa.png",
                Precio = 289.99,
                Oferta = 299.00f,
                Calificacion = 5.0f,
                Imagen = "SillaGamerMaster.png",
                Estado = "Nuevo"
            });

            //Lista de Categoria
            categoria.Add(new Categorias
            {
                idCategoria = 1,
                NombreCategoria = "Otros",
                ImagenCategoria = "bolsa.png",
                
            });

            categoria.Add(new Categorias
            {
                idCategoria = 2,
                NombreCategoria = "Roperos",
                ImagenCategoria = "closet.png",

            });

            categoria.Add(new Categorias
            {
                idCategoria = 3,
                NombreCategoria = "Estantes",
                ImagenCategoria = "estante.png",

            });

            categoria.Add(new Categorias
            {
                idCategoria = 4,
                NombreCategoria = "Completos",
                ImagenCategoria = "sets.png",

            });

            categoria.Add(new Categorias
            {
                idCategoria = 5,
                NombreCategoria = "Sillones",
                ImagenCategoria = "sillon.png",

            });

            ////////////Sec
            producto.Add(new Producto
            {
                id = 65,
                idCategoria = 10,
                NombreProducto = "Casa de Fabricio",
                Descripcion = "Casa de uno de los creadores de esta app",
                categoria = "",
                Precio = 10000.00,
                Oferta = 9000000.00f,
                Calificacion = 6.0f,
                Imagen = "casafabri.jpg",
                Estado = "Viejo"

            });

        }


    }
}
