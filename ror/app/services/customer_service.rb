class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add(name)
		return 0
	end
end
