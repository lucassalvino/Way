var AlertMessages =
{
    // http://izitoast.marcelodolce.com/

    SucessMessage : function(Message, Titulo)
    {
        Titulo = this.VerificaTexto(Titulo);
        Message = this.VerificaTexto(Message);

        iziToast.success({
            id: 'success',
            title: Titulo,
            message: Message,
            position: 'topRight',
            transitionIn: 'bounceInLeft',
            // iconText: 'star',
            onOpened: function (instance, toast) {
                // console.info(instance)
            },
            onClosed: function (instance, toast, closedBy) {
                // console.info('closedBy: ' + closedBy);
            }
        });
    },
    ErrorMessage : function(Message, Titulo)
    {
        Titulo = this.VerificaTexto(Titulo);
        Message = this.VerificaTexto(Message);
        iziToast.error({
            id: 'error',
            title: Titulo,
            message: Message,
            position: 'topRight',
            transitionIn: 'fadeInDown'
        });
    },
    WarningMessage : function (Message, Titulo)
    {
        Titulo = this.VerificaTexto(Titulo);
        Message = this.VerificaTexto(Message);

        iziToast.warning({
            id: 'warning',
            title: Titulo,
            message: Message,
            position: 'topRight',
            close: true,
            transitionIn: 'flipInX',
            transitionOut: 'flipOutX'
        });
    },
    
    InfoMessage : function(Message, Titulo)
    {
        Titulo = this.VerificaTexto(Titulo);
        Message = this.VerificaTexto(Message);

        iziToast.info({
            id: 'info',
            title: Titulo,
            message: Message,
            position: 'topRight',
            transitionIn: 'bounceInRight',
        });
    },

    VerificaTexto: function (Value) {
        if (typeof Value == "undefined")
            return "";
        return Value;
    }
};