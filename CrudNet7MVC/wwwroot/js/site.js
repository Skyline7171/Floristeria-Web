// wwwroot/js/site.js

$(document).ready(function () {

    // 1. FUNCIÓN GLOBAL: Activa la animación de pálpito en el ícono del menú
    function animarCarrito() {
        const $carrito = $('#icono-carrito-nav');
        $carrito.addClass('animar-palpito');

        // Removemos la clase al terminar la animación (300ms) para que pueda reiniciarse en el siguiente clic
        setTimeout(() => $carrito.removeClass('animar-palpito'), 300);
    }

    // 2. EVENTO: Clic inicial en el botón "Añadir al Carrito"
    $(document).on('click', '.btn-añadir-carrito', function () {
        const $contenedor = $(this).closest('.contenedor-compra');
        const florId = $contenedor.data('flor-id');

        // Inicializamos la cantidad en 1
        actualizarCarritoServidor(florId, 1, $contenedor);
    });

    // 3. EVENTO: Clic en la flecha de Incrementar (+)
    $(document).on('click', '.btn-incrementar', function () {
        const $contenedor = $(this).closest('.contenedor-compra');
        const florId = $contenedor.data('flor-id');
        const stockMaximo = parseInt($contenedor.data('stock'));
        const cantidadActual = parseInt($contenedor.find('.cantidad-actual').text());
        const $msgLimite = $contenedor.find('.msg-limite');

        // VALIDACIÓN LOCAL DE STOCK (Evita peticiones innecesarias al servidor)
        if (cantidadActual >= stockMaximo) {
            $msgLimite.text(`¡Límite alcanzado! No hay más stock disponible.`)
                .stop(true, true)
                .fadeIn();

            // Creamos un temporizador limpio para que desaparezca solo en 2 segundos
            if (this.timeoutId) clearTimeout(this.timeoutId);
            this.timeoutId = setTimeout(() => {
                $msgLimite.fadeOut();
            }, 2000);

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

        $msgLimite.stop(true, true).fadeOut();

        actualizarCarritoServidor(florId, cantidadActual - 1, $contenedor);
    });

    // 5. FUNCIÓN AUXILIAR: Comunicación asíncrona (AJAX) con el controlador de C#
    function actualizarCarritoServidor(florId, cantidad, $contenedor) {
        $.post('/Carrito/ActualizarCantidadAjax', { florId: florId, nuevaCantidad: cantidad }, function (response) {
            if (response.success) {
                // Actualizar el número flotante en la barra de navegación y disparar pálpito
                $('#contador-carrito-global').text(response.totalArticulos);
                animarCarrito();

                const $btnInicial = $contenedor.find('.btn-añadir-carrito');
                const $controles = $contenedor.find('.controles-cantidad');
                const $lblCantidad = $contenedor.find('.cantidad-actual');

                if (cantidad <= 0) {
                    // Si llega a 0, restauramos el botón original y ocultamos las flechas
                    $controles.addClass('d-none');
                    $btnInicial.removeClass('d-none');
                } else {
                    // Si es mayor a 0, ocultamos el botón original y mostramos los controles con la cantidad fresca
                    $btnInicial.addClass('d-none');
                    $controles.removeClass('d-none').addClass('d-flex');
                    $lblCantidad.text(cantidad);
                }
            } else {
                // Si el servidor detectó un fallo de stock que JS no vio (auditoría concurrente)
                $contenedor.find('.msg-limite').text(response.message).fadeIn().delay(3000).fadeOut();
            }
        });
    }
});