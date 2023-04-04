(function ($) {
    var _accountService = abp.services.app.account;
    var _$form = $('form[name=TenantChangeForm]');

    //added by me
    var _loginForm = $('form[name=LoginForm]');

    function switchToSelectedTenant () {
        var tenancyName = _$form.find('input[name=TenancyName]').val();

        //added by me
        var otherTenancyName = _loginForm.find('input[name=usernameOrEmailAddress]').val();

        if (!tenancyName) {
            abp.multiTenancy.setTenantIdCookie(null);
            location.reload();
            return;
        }

        _accountService.isTenantAvailable({
            tenancyName: tenancyName
        }).done(function (result) {
            switch (result.state) {
                case 1: //Available
                    abp.multiTenancy.setTenantIdCookie(result.tenantId);
                    //_modalManager.close();
                    location.reload();
                    return;
                case 2: //InActive
                    abp.message.warn(abp.utils.formatString(abp.localization
                        .localize("TenantIsNotActive", "MultiTenancyTrials"),
                        tenancyName));
                    break;
                case 3: //NotFound
                    abp.message.warn(abp.utils.formatString(abp.localization
                        .localize("ThereIsNoTenantDefinedWithName{0}", "MultiTenancyTrials"),
                        tenancyName));
                    break;
            }
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        alert(otherTenancyName);
        switchToSelectedTenant();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            switchToSelectedTenant();
        }
    });

    $('#TenantChangeModal').on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
