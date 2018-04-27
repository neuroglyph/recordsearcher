function Result(title, name, url, description, source) {
    var self = this;

    self.Title = title;
    self.Name = name;
    self.Url = url;
    self.Description = description;
    self.Source = source;
}

// "main" employee viewmodel
function ResultsViewModel() {
    var self = this;
    self.results = ko.observableArray([]);
   
    self.loadResults = function(data) {
        var newResults = ko.utils.arrayMap(data, function(result) {
            return new Result(result.Title, result.Name, result.Url, result.Description, result.Source);
        });

        self.results(newResults);
    };

    self.resultsCount = ko.computed(function() {
        var count = 0;
        if ((typeof (self.results()) != 'undefined') && (typeof (self.results().length) != 'undefined')) {
            count = self.results().length;
        }
        return count;
    });

    self.resultCountExists = ko.computed(function () {
        var count = 0;
        if ((typeof (self.results()) != 'undefined') && (typeof(self.results().length) != 'undefined')) {
            count = self.results().length;
        }
        return self.resultsCount() > 0;
    });

    self.resultsFoundText = ko.computed(function () {
        if (self.results().length > 0)
        {
            return self.results().length + " records found";
        }
        else
        {
            return "No records found";
        }
    });

}
