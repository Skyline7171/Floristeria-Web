// wwwroot/js/site.js

$(document).ready(function () {

    // 1. FUNCIÓN GLOBAL: Animación de pálpito en el menú
    function animarCarrito() {
        const $carrito = $('#icono-carrito-nav');
        $carrito.addClass('animar-palpito');
        setTimeout(() => $carrito.removeClass('animar-palpito'), 300);
    }

    // 2. EVENTO: Clic inicial en "Añadir al Carrito"
    $(document).on('click', '.btn-añadir-carrito', function () {
        const $contenedor = $(this).closest('.contenedor-compra');
        const florId = $contenedor.data('flor-id');
        actualizarCarritoServidor(florId, 1, $contenedor);
    });

    // 3. EVENTO: Clic en la flecha de Incrementar (+)
    $(document).on('click', '.btn-incrementar', function () {
        const $boton = $(this);
        const $contenedor = $boton.closest('.contenedor-compra');
        const florId = $contenedor.data('flor-id');
        const stockMaximo = parseInt($contenedor.data('stock'));
        const cantidadActual = parseInt($contenedor.find('.cantidad-actual').text());
        const $msgLimite = $contenedor.find('.msg-limite');

        if (cantidadActual >= stockMaximo) {
            mostrarAlertaInteligente($msgLimite, $boton, `¡Límite alcanzado! No hay más stock disponible.`);
            return;
        }

        actualizarCarritoServidor(florId, cantidadActual + 1, $contenedor);
    });

    // 4. EVENTO: Clic en la flecha de Decrementar (-)
    $(document).on('click', '.btn-decrementar', function () {
        const $contenedor = $(this).closest('.contenedor-compra');
        const florId = $contenedor.data('flor-id');
        const cantidadActual = parseInt($contenedor.find('.cantidad-actual').text());
        const $msgLimite = $contenedor.find('.msg-limite');

        // --- BORRADO FULMINANTE AL RESTAR ---
        // 1. Cancelamos cualquier temporizador del botón más
        const $btnIncrementar = $contenedor.find('.btn-incrementar');
        let timeoutId = $btnIncrementar.data('timeout-id');
        if (timeoutId) {
            clearTimeout(timeoutId);
            $btnIncrementar.data('timeout-id', null);
        }

        // 2. Forzamos la desaparición total usando CSS e ignorando animaciones
        $msgLimite.stop(true, true).css("display", "none").text("").hide();

        actualizarCarritoServidor(florId, cantidadActual - 1, $contenedor);
    });

    // 5. FUNCIÓN CENTRALIZADA PARA MOSTRAR LA ALERTA
    function mostrarAlertaInteligente($elementoMsg, $elementoBoton, texto) {
        $elementoMsg.text(texto).stop(true, true).fadeIn();

        let timeoutId = $elementoBoton.data('timeout-id');
        if (timeoutId) {
            clearTimeout(timeoutId);
        }

        timeoutId = setTimeout(function () {
            $elementoMsg.fadeOut(function () {
                // Cuando termine de desvanecerse, vaciamos el texto por seguridad
                $(this).text("");
            });
        }, 2000);

        $elementoBoton.data('timeout-id', timeoutId);
    }

    // 6. FUNCIÓN AUXILIAR: Comunicación asíncrona (AJAX) con ASP.NET Core
    function actualizarCarritoServidor(florId, cantidad, $contenedor) {
        $.post('/Carrito/ActualizarCantidadAjax', { florId: florId, nuevaCantidad: cantidad }, function (response) {
            const $btnInicial = $contenedor.find('.btn-añadir-carrito');
            const $controles = $contenedor.find('.controles-cantidad');
            const $lblCantidad = $contenedor.find('.cantidad-actual');
            const $msgLimite = $contenedor.find('.msg-limite');
            const $btnIncrementar = $contenedor.find('.btn-incrementar');

            if (response.success) {
                $('#contador-carrito-global').text(response.totalArticulos);
                animarCarrito();

                if (cantidad <= 0) {
                    $controles.addClass('d-none').removeClass('d-flex');
                    $btnInicial.removeClass('d-none');

                    // --- LIMPIEZA EXTREMA CUANDO LLEGA A 0 ---
                    // Si el producto se eliminó del carrito, el mensaje DEBE morir sí o sí
                    let timeoutId = $btnIncrementar.data('timeout-id');
                    if (timeoutId) clearTimeout(timeoutId);
                    $msgLimite.stop(true, true).css("display", "none").text("").hide();
                } else {
                    $btnInicial.addClass('d-none');
                    $controles.removeClass('d-none').addClass('d-flex');
                    $lblCantidad.text(cantidad);
                }
            } else {
                mostrarAlertaInteligente($msgLimite, $btnIncrementar, response.message);
            }
        });
    }

    // ==========================================
    // SISTEMA DE BÚSQUEDA Y FILTRADO ASÍNCRONO
    // ==========================================

    let timerBusqueda;

    // Escuchar cuando el usuario escribe en el buscador
    $(document).on('input', '#input-busqueda', function () {
        clearTimeout(timerBusqueda);
        // Esperamos 300 milisegundos desde que dejó de escribir para mandar la petición (Debounce)
        timerBusqueda = setTimeout(ejecutarFiltroCombinado, 300);
    });

    // Escuchar cuando el usuario cambia la categoría en el select
    $(document).on('change', '#select-categoria', function () {
        ejecutarFiltroCombinado();
    });

    function ejecutarFiltroCombinado() {
        const textoBusqueda = $('#input-busqueda').val();
        const idCategoria = $('#select-categoria').val();

        // Enviamos las variables al backend de C#
        $.post('/Home/FiltrarCatalogo', { buscar: textoBusqueda, categoriaId: idCategoria }, function (htmlResponse) {
            // Reemplazamos el catálogo viejo con las nuevas tarjetas filtradas en tiempo real
            $('#contenedor-catalogo-flores').html(htmlResponse);
        });
    }
});