class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add_customer(request)
		c = User.new
		request_to_customer(request, c)
		c.in_opensea = 0
		c.add_date = Time.now
		begin
			c.save
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e)
		end
		return TdCustomerResult.new(:result => true, :customer => c)
	end
	def get_customer_by_id(customer_id)
		begin
			c = Customer.find(customer_id)
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e)
		end
		return TdCustomerResult.new(:result => true, :customer => c)
	end
	def get_visit_records_by_customer(customer_id)
		c = Customer.includes(:visit_records).find(customer_id)
		records = c.visit_records
	end
	def add_visit_record(customer_id, title, remark, visit_date, user_id)
		r = VisitRecord.new
		r.customer_id = customer_id
		r.title = title
		r.remark = remark
		r.visit_date = visit_date
		r.user_id = user_id
		r.save
		return r
	end
	def save_customer(request)
		begin
			c = Customer.find(request.id)
			request_to_customer(request, c)
			c.save
			# 当客户的负责人发生变化...
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e)
		end
		TdCustomerResult.new(:result => true, :customer => c)
	end
	def find_customers(request)
		customers = Customer.order('updated_at desc')
		customers = customers.find_by_name(request.name) unless request.name.blank?
		customers = customers.find_by_contactman(request.contact_man) unless request.contact_man.blank?
		customers = customers.find_by_sales(request.sales_id) unless request.sales_id==0
		customers = customers.find_by_addtime(request.add_date_from, request.add_date_from)
		TdCustomerResult.new(:result => true, :customers => customers)
	end
	def request_to_customer(request, customer)
		customer.name = request.name
		customer.user_id = request.user_id
		customer.web_site = request.web_site
		customer.contact_man = request.contact_man
		customer.qq = request.qq
		customer.tel = request.tel
		customer.ext = request.ext
		customer.mobile = request.mobile
		customer.fax = request.fax
		customer.email = request.email
		customer.position = request.position
		customer.buy_intent = request.buy_intent
		customer.source = request.source
		customer.industry_type = request.industry_type
		customer.rank_id = request.rank_id
		customer.area = request.area
		customer.address = request.address
		customer.remark = request.remark
		customer.keywords = request.keywords
	end
end
