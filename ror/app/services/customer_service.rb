class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add(name)
		return Customer.first
	end
end
