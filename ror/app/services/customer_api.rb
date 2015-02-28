class CustomerApi < ActionWebService::API::Base
	api_method :add_customer, :expects => [{:customer=>TdCustomerRequest}], :returns => [TdCustomerResult]
	api_method :get_customer_by_id, :expects => [{:customer_id => :int}], :returns => [TdCustomerResult]
end
