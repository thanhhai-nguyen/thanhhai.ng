function validUnitPrice(src, args) {
         var value = $('#txtUnitPrice').val();
         var $err = $('#validUnitPrice');
         if ((String(value).length == 0) || isNaN(value)) {
             $err.html("* Unit price must be number");
            args.IsValid = false;
         } else if (value <= 0) {
             $err.html("* Unit price must be positive");
             args.IsValid = false;
         }
}