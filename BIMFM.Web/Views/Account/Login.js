(function () {

    $(function () {

        function CheckedInput() {
            if ($("#EmailAddressInput").val().length === 0) {
                abp.message.error(abp.localization.localize("Pleaseenterusername", 'BIMFM'), abp.localization.localize("LoginFailed", 'BIMFM'));
                return false;
            }
            if ($("#PasswordInput").val().length === 0) {
                abp.message.error(abp.localization.localize("Pleaseenterpassword", 'BIMFM'), abp.localization.localize("LoginFailed", 'BIMFM'));
                return false;
            }
            return true;
        }

        $('#LoginButton').click(function (e) {
            e.preventDefault();
            if (!CheckedInput()) {
                return false;
            }
            abp.ui.setBusy(
                $('#LoginArea'),
                abp.ajax({
                    url: abp.appPath + 'Account/Login',
                    type: 'POST',
                    data: JSON.stringify({
                        tenancyName: $('#TenancyName').val(),
                        usernameOrEmailAddress: $('#EmailAddressInput').val(),
                        password: $('#PasswordInput').val(),
                        rememberMe: $('#RememberMeInput').is(':checked'),
                        returnUrlHash: $('#ReturnUrlHash').val(),
                        returnUrl: $('#ReturnUrl').val()
                    }),
                    abpHandleError: true,
                    error: function(err, a, b) {
                        abp.message.error(err, a);
                    }
                })
            );
        });

        $('a.social-login-link').click(function () {
            var $a = $(this);
            var $form = $a.closest('form');
            $form.find('input[name=provider]').val($a.attr('data-provider'));
            $form.submit();
        });

        $('#ReturnUrlHash').val(location.hash);

        $('#LoginForm input:first-child').focus();
    });

})();