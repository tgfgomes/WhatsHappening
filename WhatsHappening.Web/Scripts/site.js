function setOptionsOnSelect(data, selector, doNotIncludeBlanckOption) {
    var items = '<option></option>';
    if (doNotIncludeBlanckOption) {
        items = '';
    }
    if (data)
        $.each(data, function (i, state) {
            items += "<option value='" + state.Key + "'>" + state.Value + "</option>";
        });
    selector.html(items);
}