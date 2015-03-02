class CustomerApi < ActionWebService::API::Base
	api_method :add_customer, :expects => [{:customer=>TdCustomerRequest}], :returns => [TdCustomerResult]
	api_method :get_customer_by_id, :expects => [{:customer_id => :int}], :returns => [TdCustomerResult]
	api_method :get_visit_records_by_customer, :expects => [{:customer_id => :int}], :returns => [[VisitRecord]]
end
